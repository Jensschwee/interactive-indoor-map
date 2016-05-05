var infoBox = L.control({ position: 'topleft' });
var selectedLayers = [];

function createInfoBox() {
    infoBox.onAdd = function () {
        this._div = L.DomUtil.create('div');
        this._div.innerHTML = '<div class="info" id="InfoBox"><h4>Building data</h4> Click to expand</div>';
        return this._div;
    };
    drawBuildingInfoBox();
    infoBox.addTo(geoMap);
}

function drawBuildingInfoBox() {
    infoBox.update = function (props) {
        this._div.innerHTML = '<div class="info" id="InfoBox"> <h4>Building data</h4>' + (props ?
            '<span style="line-height:100%"><b>Name</b>: ' + props.Name + "</br>" +
            '<b>Surface Area:</b> ' + props.SurfaceArea + ' m<sup>2</sup>' +
            '<table class="tg">' +
            props.HTML +
            '</table></span></div>'
            : '') + '</div>';
    };
    var buildingInfoBox = function () {
        PageMethods.DrawBuildingInfoBox(onSuccess);
        function onSuccess(response, userContext, methodName) {
            if (buildingInfoBox === infoboxUpdate) {
                var json = jQuery.parseJSON(response);
                var buildingInfo = {
                    Name: json.Name,
                    SurfaceArea: json.SurfaceArea,
                    NumberOfRooms: json.NumberOfRooms,
                    HTML: ""
                };
                buildingInfo.HTML = drawSensorValuesInfoBox(json);
                infoBox.update(buildingInfo);
            }
        }
    };
    infoboxUpdate = buildingInfoBox;
    infoboxUpdate();
}

function drawFloorInfoBox() {
    infoBox.update = function (props) {
        this._div.innerHTML = '<div class="info" id="InfoBox"> <h4>Floor data</h4>' + (props ?
            '<span style="line-height:100%"><b>Floor Level</b>: ' + props.FloorName + "</br>" +
            '<b>Surface Area:</b> ' + props.SurfaceArea + ' m<sup>2</sup>' +
            '<table class="tg">' +
            props.HTML +
            '</table></div></span>'
            : '') + '</div>';
    };
    var floorInfoBox = function () {
        PageMethods.DrawFloorInfoBox(currentFloorLevel, onSuccess);
        function onSuccess(response, userContext, methodName) {
            if (infoboxUpdate === floorInfoBox) {
                var json = jQuery.parseJSON(response);
                var floorInfo = {
                    FloorName: json.FloorName,
                    SurfaceArea: json.SurfaceArea,
                    NumberOfRooms: json.NumberOfRooms,
                    HTML: ""
                };
                floorInfo.HTML = drawSensorValuesInfoBox(json);
                infoBox.update(floorInfo);
            }
        }
    };

    infoboxUpdate = floorInfoBox;
    infoboxUpdate();
}

function drawRoomInfo() {
    // method that we will use to update the control based on feature properties passed
    infoBox.update = function (props) {
        if (props != null) {
            var html = '<div class="info" id="InfoBox"><h4>Room data</h4>' + props.Name + "</br>" +
                '<b>Surface Area: </b>' + props.SurfaceArea + ' m<sup>2</sup>';
                if (props.hasOwnProperty("Alias")) {
                    html += '</br><b>Alias: </b>' + props.Alias;
                }
                html += '<table class="tg">' + props.HTML + '</table></span></div>';

            this._div.innerHTML = html;
        }
    };
}

function onEachFeature(feature, layer) {
    layer.on({
        click: highlightFeature
    });
}

function drawSelectedRoomInfoBox() {
    if (roomArray.length === 0) {
        drawFloorInfoBox();
    }
    else if (roomArray.length === 1) {
        var room = $.grep(colletionOfRoomsOnMap.features, function (value) {
            return roomArray[0] === value.properties.Name;
        });

        var roomInfo = {
            Name: '<span style="line-height:100%"><b>Name: </b>' + roomArray[0],
            SurfaceArea: room[0].properties.SurfaceArea,
            Alias: room[0].properties.Alias,
            HTML: ''
        };
        roomInfo.HTML += drawSensorValuesInfoBox(room[0].properties);
        infoBox.update(roomInfo);
    } else if (roomArray.length > 1) {
        calculateAverageSensorValues();
    }

    function calculateAverageSensorValues() {
        var roomInfo = {
            Name: '<span style="line-height:100%"><b>Rooms selected: </b>' + roomArray.length,
            Motion: 0,
            Occupants: 0,
            Temperature: 0,
            CO2: 0,
            Light: 0,
            Lumen: 0,
            TotalPowerConsumption: 0,
            HardwareConsumption: 0,
            LightConsumption: 0,
            VentilationConsumption: 0,
            OtherConsumption: 0,
            SurfaceArea: 0,
            WifiClients: 0,
            NumberOfRooms: roomArray.length,
            HTML: ""
        };

        roomArray.forEach(function (roomName, index) {
            var room = $.grep(colletionOfRoomsOnMap.features, function (value) {
                return roomName === value.properties.Name;
            });
            roomInfo.Temperature += room[0].properties.Temperature / roomArray.length;
            if (room[0].properties.Motion) {
                roomInfo.Motion += 1;
            }
            roomInfo.Occupants += room[0].properties.Occupants;

            if (room[0].properties.Light) {
                roomInfo.Light += 1;
            }

            roomInfo.CO2 += room[0].properties.CO2 / roomArray.length;
            roomInfo.Lumen += room[0].properties.Lumen / roomArray.length;
            roomInfo.TotalPowerConsumption += room[0].properties.TotalPowerConsumption;
            roomInfo.HardwareConsumption += room[0].properties.HardwareConsumption;
            roomInfo.LightConsumption += room[0].properties.LightConsumption;
            roomInfo.VentilationConsumption += room[0].properties.VentilationConsumption;
            roomInfo.OtherConsumption += room[0].properties.OtherConsumption;
            roomInfo.SurfaceArea += room[0].properties.SurfaceArea;
            roomInfo.WifiClients += room[0].properties.WifiClients;
        });

        roomInfo.HTML += drawSensorValuesInfoBox(roomInfo);

        infoBox.update(roomInfo);
    }
}

function drawSensorValuesInfoBox(sensorData) {
    var notContained = -1;
    var html = "<br/>";
    if (ActiveViews.length !== 0) {
        html += "<br/>";
    }

    if (findIndexOfView('Temperature') !== notContained) {
        html += '<tr><td class="tg-yw4l"><b>Temperature</b></td><td class="tg-yw4l"> ' + sensorData.Temperature.toFixed(1) + ' &#8451 </td></tr><br/>';
    }
    if (findIndexOfView('CO2') !== notContained) {
        html += '<tr><td class="tg-yw4l"><b>CO2</b></td><td> ' + sensorData.CO2.toFixed(0) + ' PPM </td></tr>';
    }
    if (findIndexOfView('Lumen') !== notContained) {
        if (sensorData.hasOwnProperty("NumberOfRooms")) {
            html += '<tr><td class="tg-yw4l"><b>Light</b></td><td class="tg-yw4l"> ' + sensorData.Light + " / " + sensorData.NumberOfRooms + '</td></tr>';
        } else {
            if (sensorData.Light) {
                html += '<tr><td class="tg-yw4l"><b>Light</b></td><td class="tg-yw4l"> On</td></tr>';

            } else {
                html += '<tr><td class="tg-yw4l"><b>Light</b></td><td class="tg-yw4l"> Off</td></tr>';
            }
        }
        html += '<tr><td class="tg-yw4l"><b>Lumen</b></td><td class="tg-yw4l"> ' + sensorData.Lumen.toFixed(0) + ' lm </td></tr>';
    }

    if (findIndexOfView('Motion') !== notContained) {
        if (sensorData.hasOwnProperty("NumberOfRooms")) {
            html += '<tr><td class="tg-yw4l"><b>Motion</b></td><td class="tg-yw4l"> ' + sensorData.Motion + " / " + sensorData.NumberOfRooms + '</td></tr>';
        } else {
            if (sensorData.Motion) {
                html += '<tr><td class="tg-yw4l"><b>Motion</b></td><td class="tg-yw4l"> Detected</td></tr>';

            } else {
                html += '<tr><td class="tg-yw4l"><b>Motion</b></td class="tg-yw4l"><td> None</td></tr>';
            }
        }
    }

    if (findIndexOfView('WifiClients') !== notContained) {
        html += '<tr><td class="tg-yw4l"><b>Wifi Clients</b></td><td class="tg-yw4l"> ' + sensorData.WifiClients + '</td></tr>';
    }

    if (findIndexOfView('Occupants') !== notContained) {
        html += '<tr><td class="tg-yw4l"><b>Occupants</b></td><td class="tg-yw4l"> ' + sensorData.Occupants + '</td></tr>';
    }

    if (findIndexOfView('TotalPowerConsumption') !== notContained) {
        html += '<tr><td class="tg-yw4l"><b>Total Power Consumption</b></td><td class="tg-yw4l"> ' + sensorData.TotalPowerConsumption.toFixed(2) + ' kWh </td></tr>';
    }
    if (findIndexOfView('HardwareConsumption') !== notContained) {
        html += '<tr><td class="tg-yw4l"><b>Hardware Consumption</b></td><td class="tg-yw4l"> ' + sensorData.HardwareConsumption.toFixed(2) + ' kWh </td></tr>';
    }
    if (findIndexOfView('LightConsumption') !== notContained) {
        html += '<tr><td class="tg-yw4l"><b>Light Consumption</b></td><td class="tg-yw4l"> ' + sensorData.LightConsumption.toFixed(2) + ' kWh </td></tr>';
    }
    if (findIndexOfView('VentilationConsumption') !== notContained) {
        html += '<tr><td class="tg-yw4l"><b>Ventilation Consumption</b></td><td class="tg-yw4l"> ' + sensorData.VentilationConsumption.toFixed(2) + ' kWh </td></tr>';
    }
    if (findIndexOfView('OtherConsumption') !== notContained) {
        html += '<tr><td class="tg-yw4l"><b>Other Consumption</b></td><td class="tg-yw4l"> ' + sensorData.OtherConsumption.toFixed(2) + ' kWh </td></tr>';
    }

    if (findIndexOfFloorView('WaterConsumption') !== notContained) {
        if (sensorData.hasOwnProperty("ColdWaterConsumption")) {
            html += '<tr><td class="tg-yw4l"><b>Cold Water Consumption</b></td><td class="tg-yw4l"> ' + sensorData.ColdWaterConsumption.toFixed(0) + ' m<sup>3</sup></td></tr>';
        }
        if (sensorData.hasOwnProperty("HotWaterConsumption")) {
            html += '<tr><td class="tg-yw4l"><b>Hot Water Consumption</b></td><td class="tg-yw4l"> ' + sensorData.HotWaterConsumption.toFixed(0) + ' m<sup>3</sup></td></tr>';
        }
    }

    return html;
}