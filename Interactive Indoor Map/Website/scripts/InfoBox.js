var infoBox = L.control({ position: 'topleft' });
var selectedLayers = [];

function drawInfobox() {
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
        if (!temporalActive) {
            PageMethods.DrawBuildingInfoBox(onSuccess);
        } else {
            var dateResult = document.getElementById("daterangepicker").value;
            var dateResultArray = dateResult.split(" - ");
            var fromDateResult = dateResultArray[0].split("/");
            var toDateResult = dateResultArray[1].split("/");

            var fromDate = fromDateResult[1] + "/" + fromDateResult[0] + "/" + fromDateResult[2];
            var toDate = toDateResult[1] + "/" + toDateResult[0] + "/" + toDateResult[2];  var dateResult = document.getElementById("daterangepicker").value;
            var dateResultArray = dateResult.split(" - ");
            var fromDateResult = dateResultArray[0].split("/");
            var toDateResult = dateResultArray[1].split("/");

            var fromDate = fromDateResult[1] + "/" + fromDateResult[0] + "/" + fromDateResult[2];
            var toDate = toDateResult[1] + "/" + toDateResult[0] + "/" + toDateResult[2];

            PageMethods.GetTemporalBuildingInfoBox(fromDate, toDate, onSuccess);
        }
      

        function onSuccess(response, userContext, methodName) {
            if (buildingInfoBox === infoboxDataUpdate) {
                var json = jQuery.parseJSON(response);
                infoboxDataCached = json;
                infoboxUpdate(json);
            }
        }
    };
    var infoboxBuildingUpdate = function (json) {
        var buildingInfo = {
            Name: json.Name,
            SurfaceArea: json.SurfaceArea,
            NumberOfRooms: json.NumberOfRooms,
            HTML: ""
        };
        if (!temporalActive) {
            buildingInfo.HTML = getLiveSensorValuesInfoBox(json);
        } else {
            buildingInfo.HTML = getTemporalSensorValuesInfoBox(json);
        }
        infoBox.update(buildingInfo);
    }
    infoboxDataUpdate = buildingInfoBox;
    infoboxUpdate = infoboxBuildingUpdate;
    infoboxDataUpdate();
}

function drawFloorInfobox() {
    infoBox.update = function (props) {
        this._div.innerHTML = '<div class="info" id="InfoBox"> <h4>Floor data</h4>' + (props ?
            '<span style="line-height:100%"><b>Floor Level</b>: ' + props.Name + "</br>" +
            '<b>Surface Area:</b> ' + props.SurfaceArea + ' m<sup>2</sup>' +
            '<table class="tg">' +
            props.HTML +
            '</table></div></span>'
            : '') + '</div>';
    };
    var floorInfoBox = function () {
        if (!temporalActive) {
            PageMethods.DrawFloorInfoBox(currentFloorLevel, onSuccess);
        } else {
            var dateResult = document.getElementById("daterangepicker").value;
            var dateResultArray = dateResult.split(" - ");
            var fromDateResult = dateResultArray[0].split("/");
            var toDateResult = dateResultArray[1].split("/");

            var fromDate = fromDateResult[1] + "/" + fromDateResult[0] + "/" + fromDateResult[2];
            var toDate = toDateResult[1] + "/" + toDateResult[0] + "/" + toDateResult[2];
            PageMethods.GetTemporalFloorInfoBox(currentFloorLevel, fromDate, toDate, onSuccess);
        }
        function onSuccess(response, userContext, methodName) {
            if (infoboxDataUpdate === floorInfoBox) {
                var json = jQuery.parseJSON(response);
                infoboxDataCached = json;
                infoboxUpdate(json);
            }
        }
    };
    var infoboxFloorUpdate = function (json) {
        var floorInfo = {
            Name: json.Name,
            SurfaceArea: json.SurfaceArea,
            NumberOfRooms: json.NumberOfRooms,
            HTML: ""
        };
        if (!temporalActive) {
            floorInfo.HTML = getLiveSensorValuesInfoBox(json);
        } else {
            floorInfo.HTML = getTemporalSensorValuesInfoBox(json);
        }
        infoBox.update(floorInfo);
    }
    infoboxUpdate = infoboxFloorUpdate;
    infoboxDataUpdate = floorInfoBox;
    infoboxDataUpdate();
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
        drawFloorInfobox();
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
        if (!temporalActive)
        {
            roomInfo.HTML += getLiveSensorValuesInfoBox(room[0].properties);
        } else {
            roomInfo.HTML += getTemporalSensorValuesInfoBox(room[0].properties);

        }
        infoBox.update(roomInfo);
    } else if (roomArray.length > 1) {
        if (!temporalActive) {
            calculateAverageLiveSensorValues();
        } else {
            calculateAverageTemporalSensorValues();
        }
    }

    function calculateAverageLiveSensorValues() {
        var roomInfo = {
            Name: '<span style="line-height:100%"><b>Rooms selected: </b>' + roomArray.length,
            Motion: 0,
            Occupants: 0,
            Temperature: 0,
            CO2: 0,
            Light: 0,
            Lux: 0,
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
            roomInfo.Lux += room[0].properties.Lux / roomArray.length;
            roomInfo.TotalPowerConsumption += room[0].properties.TotalPowerConsumption;
            roomInfo.HardwareConsumption += room[0].properties.HardwareConsumption;
            roomInfo.LightConsumption += room[0].properties.LightConsumption;
            roomInfo.VentilationConsumption += room[0].properties.VentilationConsumption;
            roomInfo.OtherConsumption += room[0].properties.OtherConsumption;
            roomInfo.SurfaceArea += room[0].properties.SurfaceArea;
            roomInfo.WifiClients += room[0].properties.WifiClients;
        });

        roomInfo.HTML += getLiveSensorValuesInfoBox(roomInfo);

        infoBox.update(roomInfo);
    }

    function calculateAverageTemporalSensorValues() {
        var roomInfo = {
            Name: '<span style="line-height:100%"><b>Rooms selected: </b>' + roomArray.length,
            MinObservedMotion: 0,
            AverageMotion: 0,
            MaxObservedMotion: 0,
            MinObservedOccupants: Number.MAX_SAFE_INTEGER,
            AverageOccupants: 0,
            MaxObservedOccupants: 0,
            MinObservedTemperature: Number.MAX_SAFE_INTEGER,
            AverageTemperature: 0,
            MaxObservedTemperature: 0,
            MinObservedCO2: Number.MAX_SAFE_INTEGER,
            AverageCO2: 0,
            MaxObservedCO2: 0,
            MinObservedLight: Number.MAX_SAFE_INTEGER,
            AverageLight: 0,
            MaxObservedLight: 0,
            MinObservedLux: Number.MAX_SAFE_INTEGER,
            AverageLux: 0,
            MaxObservedLux: 0,
            MinObservedTotalPowerConsumption: Number.MAX_SAFE_INTEGER,
            AverageTotalPowerConsumption: 0,
            MaxObservedTotalPowerConsumption: 0,
            MinObservedHardwareConsumption: Number.MAX_SAFE_INTEGER,
            AverageHardwareConsumption: 0,
            MaxObservedHardwareConsumption: 0,
            MinObservedLightConsumption: Number.MAX_SAFE_INTEGER,
            AverageLightConsumption: 0,
            MaxObservedLightConsumption: 0,
            MinObservedVentilationConsumption: Number.MAX_SAFE_INTEGER ,
            AverageVentilationConsumption: 0,
            MaxObservedVentilationConsumption: 0,
            MinObservedOtherConsumption: Number.MAX_SAFE_INTEGER,
            AverageOtherConsumption: 0,
            MaxObservedOtherConsumption: 0,
            MinObservedWifiClients: Number.MAX_SAFE_INTEGER,
            AverageWifiClients: 0,
            MaxObservedWifiClients: 0,
            SurfaceArea: 0,
            NumberOfRooms: roomArray.length,
            HTML: ""
        };

        roomArray.forEach(function (roomName, index) {
            var room = $.grep(colletionOfRoomsOnMap.features, function (value) {
                return roomName === value.properties.Name;
            });
            if (roomInfo.MinObservedMotion > room[0].properties.MinObservedMotion) {
                roomInfo.MinObservedMotion = room[0].properties.MinObservedMotion;
            }

            roomInfo.AverageMotion += room[0].properties.AverageMotion / roomArray.length;

            if (roomInfo.MaxObservedMotion < room[0].properties.MaxObservedMotion) {
                roomInfo.MaxObservedMotion = room[0].properties.MaxObservedMotion;
            }

            roomInfo.MinObservedOccupants += room[0].properties.MinObservedOccupants;
            roomInfo.AverageOccupants += room[0].properties.AverageOccupants;
            roomInfo.MaxObservedOccupants += room[0].properties.MaxObservedOccupants;

            if (roomInfo.MinObservedTemperature > room[0].properties.MinObservedTemperature) {
                roomInfo.MinObservedTemperature = room[0].properties.MinObservedTemperature;
            }

            roomInfo.AverageTemperature += room[0].properties.AverageTemperature / roomArray.length;

            if (roomInfo.MaxObservedTemperature < room[0].properties.MaxObservedTemperature) {
                roomInfo.MaxObservedTemperature = room[0].properties.MaxObservedTemperature;
            }

            if (roomInfo.MinObservedCO2 > room[0].properties.MinObservedCO2) {
                roomInfo.MinObservedCO2 = room[0].properties.MinObservedCO2;
            }

            roomInfo.AverageCO2 += room[0].properties.AverageCO2 / roomArray.length;

            if (roomInfo.MaxObservedCO2 < room[0].properties.MaxObservedCO2) {
                roomInfo.MaxObservedCO2 = room[0].properties.MaxObservedCO2;
            }

            if (roomInfo.MinObservedLight > room[0].properties.MinObservedLight) {
                roomInfo.MinObservedLight = room[0].properties.MinObservedLight;
            }

            roomInfo.AverageLight += room[0].properties.AverageLight / roomArray.length;

            if (roomInfo.MaxObservedLight < room[0].properties.MaxObservedLight) {
                roomInfo.MaxObservedLight = room[0].properties.MaxObservedLight;
            }

            if (roomInfo.MinObservedLux > room[0].properties.MinObservedLux) {
                roomInfo.MinObservedLux = room[0].properties.MinObservedLux;
            }

            roomInfo.AverageLux += room[0].properties.AverageLux / roomArray.length;

            if (roomInfo.MaxObservedLux < room[0].properties.MaxObservedLux) {
                roomInfo.MaxObservedLux = room[0].properties.MaxObservedLux;
            }

            roomInfo.MinObservedTotalPowerConsumption += room[0].properties.MinObservedTotalPowerConsumption;
            roomInfo.AverageTotalPowerConsumption += room[0].properties.AverageTotalPowerConsumption;
            roomInfo.MaxObservedTotalPowerConsumption += room[0].properties.MaxObservedTotalPowerConsumption;

            roomInfo.MinObservedHardwareConsumption += room[0].properties.MinObservedHardwareConsumption;
            roomInfo.AverageHardwareConsumption += room[0].properties.AverageHardwareConsumption;
            roomInfo.MaxObservedHardwareConsumption += room[0].properties.MaxObservedHardwareConsumption;

            roomInfo.MinObservedLightConsumption += room[0].properties.MinObservedLightConsumption;
            roomInfo.AverageLightConsumption += room[0].properties.AverageLightConsumption;
            roomInfo.MaxObservedLightConsumption += room[0].properties.MaxObservedLightConsumption;

            roomInfo.MinObservedVentilationConsumption += room[0].properties.MinObservedVentilationConsumption;
            roomInfo.AverageVentilationConsumption += room[0].properties.AverageVentilationConsumption;
            roomInfo.MaxObservedVentilationConsumption += room[0].properties.MaxObservedVentilationConsumption;

            roomInfo.MinObservedOtherConsumption += room[0].properties.MinObservedOtherConsumption;
            roomInfo.AverageOtherConsumption += room[0].properties.AverageOtherConsumption;
            roomInfo.MaxObservedOtherConsumption += room[0].properties.MaxObservedOtherConsumption;

            roomInfo.MinObservedWifiClients += room[0].properties.MinObservedWifiClients;
            roomInfo.AverageWifiClients += room[0].properties.AverageWifiClients;
            roomInfo.MaxObservedWifiClients += room[0].properties.MaxObservedWifiClients;

            roomInfo.SurfaceArea += room[0].properties.SurfaceArea;
        });

        roomInfo.HTML += getTemporalSensorValuesInfoBox(roomInfo);

        infoBox.update(roomInfo);
    }
}

function getTemporalSensorValuesInfoBox(sensorData) {
    var notContained = -1;
    var html = "<br/>";
    if (ActiveViews.length !== 0 || ActiveFloorViews.length !== 0) {
        html += "<br/>";
        html += '<tr><th>Sensor Type</th><th>Minimum</th><th>Average</th><th>Maximum</th></tr>';

    }

    if (findIndexOfView('Temperature') !== notContained) {
        html += '<tr><td class="tg-yw4l"><b>Temperature</b></td><td class="tg-yw4l"> ' + sensorData.MinObservedTemperature.toFixed(1) + ' &#8451 </td><td class="tg-yw4l"> ' + sensorData.AverageTemperature.toFixed(1) + ' &#8451 </td><td class="tg-yw4l"> ' + sensorData.MaxObservedTemperature.toFixed(1) + ' &#8451 </td></tr>';
    }
    if (findIndexOfView('CO2') !== notContained) {
        html += '<tr><td class="tg-yw4l"><b>CO2</b></td><td> ' + sensorData.MinObservedCO2.toFixed(0) + ' PPM </td><td> ' + sensorData.AverageCO2.toFixed(0) + ' PPM </td><td> ' + sensorData.MaxObservedCO2.toFixed(0) + ' PPM </td></tr>';
    }
    if (findIndexOfView('Lux') !== notContained) {
        html += '<tr><td class="tg-yw4l"><b>Light</b></td><td> ' + sensorData.MinObservedLight.toFixed(0) + '%</td><td> ' + ((sensorData.AverageLight) * 100).toFixed(1) + '%</td><td> ' + sensorData.MaxObservedLight.toFixed(0) + '00%</td></tr>';

        html += '<tr><td class="tg-yw4l"><b>Lux</b></td><td class="tg-yw4l"> ' + sensorData.MinObservedLux.toFixed(0) + ' lx </td><td class="tg-yw4l"> ' + sensorData.AverageLux.toFixed(0) + ' lx </td><td class="tg-yw4l"> ' + sensorData.MaxObservedLux.toFixed(0) + ' lx </td></tr>';
    }

    if (findIndexOfView('Motion') !== notContained) {
        html += '<tr><td class="tg-yw4l"><b>Average Motion</b></td></td><td class="tg-yw4l"> ' + sensorData.MinObservedMotion + '%</td><td class="tg-yw4l"> ' + ((sensorData.AverageMotion)*100).toFixed(1) + '%</td></td><td class="tg-yw4l"> ' + sensorData.MaxObservedMotion + '00%</td></tr>';
    }

    if (findIndexOfView('WifiClients') !== notContained) {
        html += '<tr><td class="tg-yw4l"><b>Wifi Clients</b></td><td class="tg-yw4l"> ' + sensorData.MinObservedWifiClients + '</td><td class="tg-yw4l"> ' + sensorData.AverageWifiClients + '</td></td><td class="tg-yw4l"> ' + sensorData.MaxObservedWifiClients + '</td></tr>';
    }

    if (findIndexOfView('Occupants') !== notContained) {
        html += '<tr><td class="tg-yw4l"><b>Occupants</b></td><td class="tg-yw4l"> ' + sensorData.MinObservedOccupants + '</td><td class="tg-yw4l"> ' + sensorData.AverageOccupants + '</td><td class="tg-yw4l"> ' + sensorData.MaxObservedOccupants + '</td></tr>';
    }

    if (findIndexOfView('TotalPowerConsumption') !== notContained) {
        html += '<tr><td class="tg-yw4l"><b>Total Power Consumption</b></td><td class="tg-yw4l"> ' + sensorData.MinObservedTotalPowerConsumption.toFixed(2) + ' kWh </td><td class="tg-yw4l"> ' + sensorData.AverageTotalPowerConsumption.toFixed(2) + ' kWh </td><td class="tg-yw4l"> ' + sensorData.MaxObservedTotalPowerConsumption.toFixed(2) + ' kWh </td></tr>';
    }

    if (findIndexOfView('HardwareConsumption') !== notContained) {
        html += '<tr><td class="tg-yw4l"><b>Hardware Consumption</b></td><td class="tg-yw4l"> ' + sensorData.MinObservedHardwareConsumption.toFixed(2) + ' kWh </td><td class="tg-yw4l"> ' + sensorData.AverageHardwareConsumption.toFixed(2) + ' kWh </td><td class="tg-yw4l"> ' + sensorData.MaxObservedHardwareConsumption.toFixed(2) + ' kWh </td></tr>';

    }
    if (findIndexOfView('LightConsumption') !== notContained) {
        html += '<tr><td class="tg-yw4l"><b>Light Consumption</b></td><td class="tg-yw4l"> ' + sensorData.MinObservedLightConsumption.toFixed(2) + ' kWh </td><td class="tg-yw4l"> ' + sensorData.AverageLightConsumption.toFixed(2) + ' kWh </td><td class="tg-yw4l"> ' + sensorData.MaxObservedLightConsumption.toFixed(2) + ' kWh </td></tr>';
    }
    if (findIndexOfView('VentilationConsumption') !== notContained) {
        html += '<tr><td class="tg-yw4l"><b>Ventilation Consumption</b></td><td class="tg-yw4l"> ' + sensorData.MinObservedVentilationConsumption.toFixed(2) + ' kWh </td><td class="tg-yw4l"> ' + sensorData.AverageVentilationConsumption.toFixed(2) + ' kWh </td><td class="tg-yw4l"> ' + sensorData.MaxObservedVentilationConsumption.toFixed(2) + ' kWh </td></tr>';
    }
    if (findIndexOfView('OtherConsumption') !== notContained) {
        html += '<tr><td class="tg-yw4l"><b>Average Other Consumption</b></td><td class="tg-yw4l"> ' + sensorData.MinObservedOtherConsumption.toFixed(2) + ' kWh </td><td class="tg-yw4l"> ' + sensorData.AverageOtherConsumption.toFixed(2) + ' kWh </td><td class="tg-yw4l"> ' + sensorData.MaxObservedOtherConsumption.toFixed(2) + ' kWh </td></tr>';
    }

    if (findIndexOfFloorView('WaterConsumption') !== notContained) {
        if (sensorData.hasOwnProperty("MinObservedColdWaterConsumption")) {
            html += '<tr><td class="tg-yw4l"><b>Cold Water Consumption</b></td><td class="tg-yw4l"> ' + sensorData.MinObservedColdWaterConsumption.toFixed(0) + ' m<sup>3</sup></td><td class="tg-yw4l"> ' + sensorData.AverageColdWaterConsumption.toFixed(0) + ' m<sup>3</sup></td><td class="tg-yw4l"> ' + sensorData.MaxObservedColdWaterConsumption.toFixed(0) + ' m<sup>3</sup></td></tr>';
        }
        if (sensorData.hasOwnProperty("MinObservedHotWaterConsumption")) {
            html += '<tr><td class="tg-yw4l"><b>Hot Water Consumption</b></td><td class="tg-yw4l"> ' + sensorData.MinObservedHotWaterConsumption.toFixed(0) + ' m<sup>3</sup></td><td class="tg-yw4l"> ' + sensorData.AverageHotWaterConsumption.toFixed(0) + ' m<sup>3</sup></td><td class="tg-yw4l"> ' + sensorData.MaxObservedHotWaterConsumption.toFixed(0) + ' m<sup>3</sup></td></tr>';
        }
    }

    return html;
}

function getLiveSensorValuesInfoBox(sensorData) {
    var notContained = -1;
    var html = "<br/>";
    if (ActiveViews.length !== 0) {
        html += "<br/>";
    }

    if (findIndexOfView('Temperature') !== notContained) {
        html += '<tr><td class="tg-yw4l"><b>Temperature</b></td><td class="tg-yw4l"> ' + sensorData.Temperature.toFixed(1) + ' &#8451 </td></tr>';
    }
    if (findIndexOfView('CO2') !== notContained) {
        html += '<tr><td class="tg-yw4l"><b>CO2</b></td><td> ' + sensorData.CO2.toFixed(0) + ' PPM </td></tr>';
    }
    if (findIndexOfView('Lux') !== notContained) {
        if (sensorData.hasOwnProperty("NumberOfRooms")) {
            html += '<tr><td class="tg-yw4l"><b>Light</b></td><td class="tg-yw4l"> ' + sensorData.Light + " / " + sensorData.NumberOfRooms + '</td></tr>';
        } else {
            if (sensorData.Light) {
                html += '<tr><td class="tg-yw4l"><b>Light</b></td><td class="tg-yw4l"> On</td></tr>';

            } else {
                html += '<tr><td class="tg-yw4l"><b>Light</b></td><td class="tg-yw4l"> Off</td></tr>';
            }
        }
        html += '<tr><td class="tg-yw4l"><b>Lux</b></td><td class="tg-yw4l"> ' + sensorData.Lux.toFixed(0) + ' lx </td></tr>';
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