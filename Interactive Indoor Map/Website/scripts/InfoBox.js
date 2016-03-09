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
            '<h4>Occupancy</h4>' +
            '<b>Occupants</b>: ' + props.Occupants +
            '<br/><br/><h4>Power Consumption</h4>' +
            '<b>Hardware</b>: ' + props.HardwareConsumption +
            '<br/> <b>Light</b>: ' + props.LightConsumption +
            '<br/> <b>Ventilation</b>: ' + props.VentilationConsumption +
            '<br/> <b>Other</b>: ' + props.OtherConsumption +
            '<br/> <b>Total</b>: ' + props.TotalPowerConsumption +
            '<br/><br/><h4>Water Consumption</h4>' +
            '<b>Cold Water</b>: ' + props.ColdWaterConsumption +
            '<br/><b>Hot Water</b>: ' + props.HotWaterConsumption +
            '</span>'
            : 'Click to expand') + '</div>';
    };

    PageMethods.DrawBuildingInfoBox(onSuccess);
    function onSuccess(response, userContext, methodName) {
        infoBox.update(jQuery.parseJSON(response));
    }
}

function drawFloorInfoBox() {
    infoBox.update = function (props) {
        this._div.innerHTML = '<div class="info" id="InfoBox"> <h4>Floor data</h4>' + (props ?
            '<span style="line-height:100%"><h5><b>Floor Level</b>: ' + props.FloorLevel + '</h5>' +
            '<br/><h4>Power Consumption</h4>' +
            '<b>Hardware</b>: ' + props.HardwareConsumption +
            '<br/> <b>Light</b>: ' + props.LightConsumption +
            '<br/> <b>Ventilation</b>: ' + props.VentilationConsumption +
            '<br/> <b>Other</b>: ' + props.OtherConsumption +
            '<br/><b>Total</b>: ' + props.TotalPowerConsumption +
            '<br/><br/><h4>Water Consumption</h4>' +
            '<b>Cold Water</b>: ' + props.ColdWaterConsumption +
            '<br/><b>Hot Water</b>: ' + props.HotWaterConsumption +
            '</div></span>'
            : 'Click to expand') + '</div>';
    };

    PageMethods.DrawFloorInfoBox(currentFloorLevel, onSuccess);
    function onSuccess(response, userContext, methodName) {
        infoBox.update(jQuery.parseJSON(response));
    }
    
}

function drawRoomInfo() {
   // method that we will use to update the control based on feature properties passed
    infoBox.update = function (props) {
        this._div.innerHTML = '<div class="info" id="InfoBox"><h4>Room data</h4>' + (props ?
            '<span style="line-height:100%"><h5><b>Name: </b>' + props.RoomName + '</h5>' +
            '<h4>Occupancy</h4>' +
            '<b>Motion</b>: ' + props.IsMotionDetected +
            '<br/> <b>Occupants</b>: ' + props.Occupants +
            '<br/><br/><h4>Air</h4>' +
            '<b>Temperature</b>: ' + props.Temperature + '&#8451' +
            '<br/> <b>CO2</b>: ' + props.CO2 +
            '<br/><br/><h4>Light</h4>' +
            '<b>Lighting</b>: ' + props.IsLightActivated +
            '<br/> <b>Lumen</b>: ' + props.Lumen +
            '<br/><br/><h4>Power Consumption</h4>' +
            '<b>Hardware</b>: ' + props.HardwareConsumption +
            '<br/> <b>Light</b>: ' + props.LightConsumption +
            '<br/> <b>Ventilation</b>: ' + props.VentilationConsumption +
            '<br/> <b>Other</b>: ' + props.OtherConsumption +
            '<br/><b>Total</b>: ' + props.TotalPowerConsumption +
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
        infoBox.update(roomSet.values().next().value);
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
            TotalPowerConsumption: 0
        };

        for (var element of roomSet) {
            roomInfo.Temperature += element.Temperature / roomSet.size;
        }
        infoBox.update(roomInfo);
    }
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