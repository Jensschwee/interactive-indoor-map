var infoBox = L.control({ position: 'topleft' });
var selectedLayers = [];

function createInfoBox() {
    infoBox.onAdd = function (map) {
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
            props.HTML +
            '</span>'
            : 'Click to expand') + '</div>';
    };

    infoboxUpdate = function () {
        PageMethods.DrawBuildingInfoBox(onSuccess);

        function onSuccess(response, userContext, methodName) {
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
    };
    infoboxUpdate();
}

function drawFloorInfoBox() {
    infoBox.update = function (props) {
        this._div.innerHTML = '<div class="info" id="InfoBox"> <h4>Floor data</h4>' + (props ?
            '<span style="line-height:100%"><b>Floor Level</b>: ' + props.FloorName + "</br>" +
            '<b>Surface Area:</b> ' + props.SurfaceArea + ' m<sup>2</sup>' +
            props.HTML +
            '</div></span>'
            : 'Click to expand') + '</div>';
    };

    infoboxUpdate = function () {
        PageMethods.DrawFloorInfoBox(currentFloorLevel, onSuccess);

        function onSuccess(response, userContext, methodName) {
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
    };
    infoboxUpdate();

}

function drawRoomInfo() {
    // method that we will use to update the control based on feature properties passed
    infoBox.update = function (props) {
        this._div.innerHTML = '<div class="info" id="InfoBox"><h4>Room data</h4>' + (props ?
            props.Name + "</br>" +
            '<b>Surface Area:</b> ' + props.SurfaceArea + ' m<sup>2</sup>' +
            props.HTML +
            '</span></div>'
            : 'Hover over a room to see info');
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

        roomArray.forEach(function (roomName, index)
        {
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
        html += '<b>Temperature</b>: ' + sensorData.Temperature.toFixed(1) + ' &#8451 <br/>';
    }
    if (findIndexOfView('CO2') !== notContained) {
        html += '<b>CO2</b>: ' + sensorData.CO2.toFixed(0) + ' PPM <br/>';
    }
    if (findIndexOfView('Lumen') !== notContained) {
        if (sensorData.hasOwnProperty("NumberOfRooms")) {
            html += '<b>Light</b>: ' + sensorData.Light + " / " + sensorData.NumberOfRooms + '<br/>';
        } else {
            if (sensorData.Light) {
                html += '<b>Light</b>: On<br/>';

            } else {
                html += '<b>Light</b>: Off<br/>';
            }
        }
        html += '<b>Lumen</b>: ' + sensorData.Lumen.toFixed(0) + ' lm <br/>';
    }
    if (findIndexOfView('TotalPowerConsumption') !== notContained) {
        html += '<b>Total Power Consumption</b>: ' + sensorData.TotalPowerConsumption.toFixed(0) + ' kWh <br/>';
    }
    if (findIndexOfView('HardwareConsumption') !== notContained) {
        html += '<b>Hardware Consumption</b>: ' + sensorData.HardwareConsumption.toFixed(0) + ' kWh <br/>';
    }
    if (findIndexOfView('LightConsumption') !== notContained) {
        html += '<b>Light Consumption</b>: ' + sensorData.LightConsumption.toFixed(0) + ' kWh <br/>';
    }
    if (findIndexOfView('VentilationConsumption') !== notContained) {
        html += '<b>Ventilation Consumption</b>: ' + sensorData.VentilationConsumption.toFixed(0) + ' kWh <br/>';
    }
    if (findIndexOfView('OtherConsumption') !== notContained) {
        html += '<b>Other Consumption</b>: ' + sensorData.OtherConsumption.toFixed(0) + ' kWh <br/>';
    }
    if (findIndexOfView('Motion') !== notContained) {
        if (sensorData.hasOwnProperty("NumberOfRooms")) {
            html += '<b>Motion</b>: ' + sensorData.Motion + " / " + sensorData.NumberOfRooms + '<br/>';
        } else {
            if (sensorData.Motion) {
                html += '<b>Motion</b>: Detected<br/>';

            } else {
                html += '<b>Motion</b>: None<br/>';
            }
        }
    }
    if (findIndexOfView('Occupants') !== notContained) {
        html += '<b>Occupants</b>: ' + sensorData.Occupants + '<br/>';
    }
    if (findIndexOfView('WifiClients') !== notContained) {
        html += '<b>Wifi Clients</b>: ' + sensorData.WifiClients + '<br/>';
    }

    return html;
}