var infoBox = L.control({ position: 'topleft' });

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
            '<span style="line-height:100%"><h5><b>Name</b>: ' + props.BuildingName + '</h5>' +
            '<b>Surface Area:</b> ' + props.SurfaceArea +
            props.HTML   +
            '</span>'
            : 'Click to expand') + '</div>';
    };

    PageMethods.DrawBuildingInfoBox(onSuccess);
    function onSuccess(response, userContext, methodName) {
        var json = jQuery.parseJSON(response);
        var buildingInfo = {
            BuildingName: json.BuildingName,
            SurfaceArea: json.SurfaceArea,
            HTML: ""
        };
        buildingInfo.HTML = infoBoxGenerateHTML(json);
        infoBox.update(buildingInfo);
    }
}

function drawFloorInfoBox() {
    infoBox.update = function (props) {
        this._div.innerHTML = '<div class="info" id="InfoBox"> <h4>Floor data</h4>' + (props ?
            '<span style="line-height:100%"><h5><b>Floor Level</b>: ' + props.FloorLevel + '</h5>' +
            '<b>Surface Area:</b> ' + props.SurfaceArea +
            props.HTML +
            '</div></span>'
            : 'Click to expand') + '</div>';
    };

    PageMethods.DrawFloorInfoBox(currentFloorLevel, onSuccess);
    function onSuccess(response, userContext, methodName) {
        var json = jQuery.parseJSON(response);
        var floorInfo = {
            FloorLevel: json.FloorLevel,
            SurfaceArea: json.SurfaceArea,
            HTML: ""
        };
        floorInfo.HTML = infoBoxGenerateHTML(json);
        infoBox.update(floorInfo);
    }
    
}

function drawRoomInfo() {
   // method that we will use to update the control based on feature properties passed
    infoBox.update = function (props) {
        this._div.innerHTML = '<div class="info" id="InfoBox"><h4>Room data</h4>' + (props ?
            props.Name + 
            '<b>Surface Area:</b> ' + props.SurfaceArea +
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

function roomInfoDrawSelected() {
    if (roomArray.length === 0) {
        drawFloorInfoBox();
    }
    else if (roomArray.length === 1) {
        var roomInfo = {
            Name: '<span style="line-height:100%"><h5><b>Name: </b>' + roomArray[0].RoomName + '</h5>',
            SurfaceArea: roomArray[0].SurfaceArea,
            HTML: ''
        };
        roomInfo.HTML += infoBoxGenerateHTML(roomArray[0]);
        infoBox.update(roomInfo);
    } else {
        var roomInfo = {
            Name: '<span style="line-height:100%"><h5><b>Rooms selected:  </b>' + roomArray.length + '</h5>',
            IsMotionDetected: 0,
            Occupants: 0,
            Temperature: 0,
            CO2: 0,
            IsLightActivated: 0,
            Lumen: 0,
            TotalPowerConsumption: 0,
            HardwareConsumption: 0,
            LightConsumption: 0,
            VentilationConsumption: 0,
            OtherConsumption: 0,
            SurfaceArea: 0,
            HTML: ""
    };

        for (var i in roomArray) {
            if (roomArray.hasOwnProperty(i)) {
                roomInfo.Temperature += roomArray[i].Temperature / roomArray.length;
                if (roomArray[i].IsMotionDetected) {
                    roomInfo.IsMotionDetected += 1;
                }
                roomInfo.Occupants += roomArray[i].Occupants;

                if (roomArray[i].IsLightActivated) {
                    roomInfo.IsLightActivated += 1;
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
    if (ViewStates.IsMotionDetected) {
        html += '<b>Motion</b>: ' + sensorData.IsMotionDetected + '<br/>';
    }
    if (ViewStates.Occupants) {
        html += '<b>Occupants</b>: ' + sensorData.Occupants + '<br/>';
    }
    if (ViewStates.Temperature) {
        html += '<b>Temperature</b>: ' + sensorData.Temperature.toFixed(1) + '&#8451' + '<br/>';
    }
    if (ViewStates.CO2) {
        html += '<b>CO2</b>: ' + sensorData.CO2 + '<br/>';
    }
    if (ViewStates.Lighting) {
        html += '<b>Lighting</b>: ' + sensorData.IsLightActivated + '<br/>';
    }
    if (ViewStates.Lumen) {
        html += '<b>Lighting</b>: ' + sensorData.Lumen + '<br/>';
    }
    if (ViewStates.HardwareConsumption) {
        html += '<b>Hardware Consumption</b>: ' + sensorData.HardwareConsumption + '<br/>';
    }
    if (ViewStates.LightConsumption) {
        html += '<b>LightConsumption</b>: ' + sensorData.LightConsumption + '<br/>';
    }
    if (ViewStates.VentilationConsumption) {
        html += '<b>VentilationConsumption</b>: ' + sensorData.VentilationConsumption + '<br/>';
    }
    if (ViewStates.OtherConsumption) {
        html += '<b>Other Consumption</b>: ' + sensorData.OtherConsumption + '<br/>';
    }
    if (ViewStates.TotalPowerConsumption) {
        html += '<b>Total PowerConsumption</b>: ' + sensorData.TotalPowerConsumption + '<br/>';
    }
    return html;

}

function highlightFeature(e) {
    var layer = e.target;
    if ($.inArray(layer.feature.properties, roomArray) === -1) {
        layer.setStyle({
            weight: 5,
            color: '#666',
            dashArray: '',
            fillOpacity: 0.7
        });

        if (!L.Browser.ie && !L.Browser.opera) {
            layer.bringToFront();
        }
        drawRoomInfo();
        roomArray.push(layer.feature.properties);
        roomInfoDrawSelected();
    } else {
        roomArray = jQuery.grep(roomArray, function (value) {
            return value != layer.feature.properties;
        });
        resetHighlight(e);
        roomInfoDrawSelected();
    }
}

function resetHighlight(e) {
    View.roomGeoJson.resetStyle(e.target);
    infoBox.update();
}