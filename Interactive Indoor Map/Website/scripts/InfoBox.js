var infoBox = L.control({ position: 'topleft' });
var selectedLayers = [];

function createInfoBox() {
    infoBox.onAdd = function (map) {
        this._div = L.DomUtil.create('div');
        this._div.innerHTML = '<div class="info" id="InfoBox"><h4>Building data</h4> Click to expand</div>';
        return this._div;
    };
    drawBuildingInfo();
    infoBox.addTo(geoMap);

}

function drawBuildingInfo() {
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
            buildingInfo.HTML = infoBoxGenerateHTML(json);
            infoBox.update(buildingInfo);
        }
    };
    infoboxUpdate();
}

function drawFloorInfoBox() {
    infoBox.update = function (props) {
        this._div.innerHTML = '<div class="info" id="InfoBox"> <h4>Floor data</h4>' + (props ?
            '<span style="line-height:100%"><b>Floor Level</b>: ' + props.FloorLevel + "</br>" +
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
                FloorLevel: json.FloorLevel,
                SurfaceArea: json.SurfaceArea,
                NumberOfRooms: json.NumberOfRooms,
                HTML: ""
            };
            floorInfo.HTML = infoBoxGenerateHTML(json);
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
        var roomInfo = {
            Name: '<span style="line-height:100%"><b>Name: </b>' + roomArray[0].Name,
            SurfaceArea: roomArray[0].SurfaceArea,
            HTML: ''
        };

        roomInfo.HTML += infoBoxGenerateHTML(roomArray[0]);
        infoBox.update(roomInfo);
    } else {
        var roomInfo = {
            Name: '<span style="line-height:100%"><b>Rooms selected:  </b>' + roomArray.length,
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
            NumberOfRooms: roomArray.length,
            HTML: ""
        };

        for (var i in roomArray) {
            if (roomArray.hasOwnProperty(i)) {
                roomInfo.Temperature += roomArray[i].Temperature / roomArray.length;
                if (roomArray[i].Motion) {
                    roomInfo.Motion += 1;
                }
                roomInfo.Occupants += roomArray[i].Occupants;

                if (roomArray[i].Light) {

                    roomInfo.Light += 1;
                }

                roomInfo.CO2 += roomArray[i].CO2 / roomArray.length;
                roomInfo.Lumen += roomArray[i].Lumen / roomArray.length;
                roomInfo.TotalPowerConsumption += roomArray[i].TotalPowerConsumption;
                roomInfo.HardwareConsumption += roomArray[i].HardwareConsumption;
                roomInfo.LightConsumption += roomArray[i].LightConsumption;
                roomInfo.VentilationConsumption += roomArray[i].VentilationConsumption;
                roomInfo.OtherConsumption += roomArray[i].OtherConsumption;
                roomInfo.SurfaceArea += roomArray[i].SurfaceArea;
            }   
        }

        roomInfo.HTML += infoBoxGenerateHTML(roomInfo);

        infoBox.update(roomInfo);
    }
}

function infoBoxGenerateHTML(sensorData) {
    var html = "<br/>";
    if (ActiveViews.length !== 0) {
        html += "<br/>";
    }
    if (findIndexOfView('Motion') !== -1) {
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
    if (findIndexOfView('Occupants') !== -1) {
        html += '<b>Occupants</b>: ' + sensorData.Occupants + '<br/>';
    }
    if (findIndexOfView('WifiClients') !== -1) {
        html += '<b>Wifi Clients</b>: ' + sensorData.WifiClients + '<br/>';
    }
    if (findIndexOfView('Temperature') !== -1) {
        html += '<b>Temperature</b>: ' + sensorData.Temperature.toFixed(1) + ' &#8451' + '<br/>';
    }
    if (findIndexOfView('CO2') !== -1) {
        html += '<b>CO2</b>: ' + sensorData.CO2.toFixed(1) + ' PPM' + '<br/>';
    }
    if (findIndexOfView('Lumen') !== -1) {
        if (sensorData.hasOwnProperty("NumberOfRooms")) {
            html += '<b>Light</b>: ' + sensorData.Light + " / " + sensorData.NumberOfRooms + '<br/>';
        } else {
            if (sensorData.Light) {
                html += '<b>Light</b>: On<br/>';

            } else {
                html += '<b>Light</b>: Off<br/>';
            }
        }

        html += '<b>Lumen</b>: ' + sensorData.Lumen.toFixed(1) + ' lm' + '<br/>';
    }

    if (findIndexOfView('TotalPowerConsumption') !== -1) {
        html += '<b>Total Power Consumption</b>: ' + sensorData.TotalPowerConsumption.toFixed(1) + '<br/>';
    }
    if (findIndexOfView('HardwareConsumption') !== -1) {
        html += '<b>Hardware Consumption</b>: ' + sensorData.HardwareConsumption.toFixed(1) + ' kWh' + '<br/>';
    }
    if (findIndexOfView('LightConsumption') !== -1) {
        html += '<b>Light Consumption</b>: ' + sensorData.LightConsumption.toFixed(1) + ' kWh' + '<br/>';
    }
    if (findIndexOfView('VentilationConsumption') !== -1) {
        html += '<b>Ventilation Consumption</b>: ' + sensorData.VentilationConsumption.toFixed(1) + ' kWh' + '<br/>';
    }
    if (findIndexOfView('OtherConsumption') !== -1) {
        html += '<b>Other Consumption</b>: ' + sensorData.OtherConsumption.toFixed(1) + ' kWh' + '<br/>';
    }
    if (findIndexOfView('PowerConsumption') !== -1) {
        html += '<b>Total Power Consumption</b>: ' + sensorData.TotalPowerConsumption.toFixed(1) + ' kWh' + '<br/>';
    }
    return html;

}