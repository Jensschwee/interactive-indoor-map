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
            '<br/>Surface Area: ' + props.SurfaceArea +
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
            '<br/>Surface Area: ' + props.SurfaceArea +
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
            '<span style="line-height:100%"><h5><b>Name: </b>' + props.RoomName + '</h5>' +
            '<br/>Surface Area: ' + props.SurfaceArea +
            props.HTML +
            '</span></div>'
            : 'Hover over a room to see info');
    };

}

function onEachFeature(feature, layer) {
    layer.on({
        click: highlightFeature
        //,
        //mouseover: highlightFeature,
        //mouseout: resetHighlight
    });
}

function roomInfoDrawSelected() {
    if (roomSet.size === 0) {
        drawFloorInfoBox();
    }
    else if (roomSet.size === 1) {
        var roomInfo = {
            RoomName: roomSet.values().next().value.RoomName,
            SurfaceArea: roomSet.values().next().value.SurfaceArea,
            HTML: ""
        };
        roomInfo.HTML = infoBoxGenerateHTML(roomSet.values().next().value);
        infoBox.update(roomInfo);
    } else {
        var roomInfo = {
            IsMotionDetected : "None",
            Occupants : 0,
            RoomName : "More selected",
            Temperature : 0,
            CO2 : 0,
            IsLightActivated : "None",
            Lumen : 0,
            TotalPowerConsumption : 0,
            HardwareConsumption : 0,
            LightConsumption : 0,
            VentilationConsumption : 0,
            OtherConsumption : 0,
            TotalPowerConsumption: 0,
            SurfaceArea: 0,
            HTML : ""
        };

        for (var element of roomSet) {
            roomInfo.Temperature += element.Temperature / roomSet.size;
            roomInfo.SurfaceArea += element.SurfaceArea;
        }
        roomInfo.HTML = infoBoxGenerateHTML(roomInfo);
        infoBox.update(roomInfo);
    }
}

function infoBoxGenerateHTML(SenserData) {
    var html = "<br/>";
    if (ViewStates.IsMotionDetected) {
        html += '<b>Motion</b>: ' + SenserData.IsMotionDetected + '<br/>';
    }
    if (ViewStates.Occupants) {
        html += '<b>Occupants</b>: ' + SenserData.Occupants + '<br/>';
    }
    if (ViewStates.Temperature) {
        html += '<b>Temperature</b>: ' + SenserData.Temperature + '&#8451' + '<br/>';
    }
    if (ViewStates.CO2) {
        html += '<b>CO2</b>: ' + SenserData.CO2 + '<br/>';
    }
    if (ViewStates.Lighting) {
        html += '<b>Lighting</b>: ' + SenserData.IsLightActivated + '<br/>';
    }
    if (ViewStates.Lumen) {
        html += '<b>Lighting</b>: ' + SenserData.Lumen + '<br/>';
    }
    if (ViewStates.Hardware) {
        html += '<b>Hardware Consumption</b>: ' + SenserData.HardwareConsumption + '<br/>';
    }
    if (ViewStates.Light) {
        html += '<b>LightConsumption</b>: ' + SenserData.LightConsumption + '<br/>';
    }
    if (ViewStates.Light) {
        html += '<b>VentilationConsumption</b>: ' + SenserData.VentilationConsumption + '<br/>';
    }
    if (ViewStates.Light) {
        html += '<b>Other Consumption</b>: ' + SenserData.OtherConsumption + '<br/>';
    }
    if (ViewStates.Light) {
        html += '<b>Total PowerConsumption</b>: ' + SenserData.TotalPowerConsumption + '<br/>';
    }
    return html;

}

function highlightFeature(e) {
    var layer = e.target;

    if (!roomSet.has(layer.feature.properties)) {
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
        roomSet.add(layer.feature.properties);
        roomInfoDrawSelected();
    } else {
        roomSet.delete(layer.feature.properties);
        resetHighlight(e);
        roomInfoDrawSelected();
    }
}

function resetHighlight(e) {
    View.roomGeoJson.resetStyle(e.target);
    infoBox.update();
}