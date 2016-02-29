var buildingInfo = L.control({ position: 'topleft' });
var floorInfo = L.control({ position: 'topleft' });
var roomInfo = L.control();
var isFloorInfoToggled = false;

function drawBuildingInfo() {
    buildingInfo.onAdd = function (map) {
        this._div = L.DomUtil.create('div', 'info');
        this.update();
        return this._div;
    };

    buildingInfo.update = function (props) {
        this._div.innerHTML = '<h4>Building data</h4>' + (props ?
            '<span style="line-height:100%"><h5>' + props.BuildingName + '</h5>' +
            '<h4>Occupancy</h4>' +
            '<b>Occupants</b>: ' + props.Occupants +
            '<br/><br/><h4>Power Consumption</h4>' +
            '<b>Hardware</b>: ' + props.HardwareConsumption +
            '<br/> <b>Light</b>: ' + props.LightConsumption +
            '<br/> <b>Ventilation</b>: ' + props.VentilationConsumption +
            '<br/> <b>Other</b>: ' + props.OtherConsumption +
            '<br/> <b>Total</b>: ' + props.TotalPowerConsumption +
            '<br/><br/><h4>Water Consumption</h4>' +
            '<b><Cold Water</b>:' + props.ColdWaterConsumption +
            '<br/> <b><Hot Water</b>: ' + props.HotWaterConsumption +
            '</span>'
            : 'Click to expand');
    };

    buildingInfo.addTo(geoMap);
}

function drawFloorInfoBox() {
    floorInfo.onAdd = function (map) {
        this._div = L.DomUtil.create('div');
        this._div.innerHTML = '<div class="info" id="floorInfoBox"><h4>Floor Data</h4> Click to expand</div>';
        return this._div;
    };

    floorInfo.addTo(geoMap);

    floorInfo.update = function (props) {
        this._div.innerHTML = '<div class="info" id="floorInfoBox"> <h4>Floor data</h4>' + (props ?
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

    
    document.getElementById("floorInfoBox").addEventListener("click", onFloorInfoClick, false);
}

function onFloorInfoClick() {
    if (!isFloorInfoToggled) {
        isFloorInfoToggled = true;
        PageMethods.DrawFloorInfoBox(currentFloorLevel, onSuccess);
        function onSuccess(response, userContext, methodName) {
            floorInfo.update(jQuery.parseJSON(response));
            document.getElementById("floorInfoBox").addEventListener("click", onFloorInfoClick, false);

        }
    } else {
        isFloorInfoToggled = false;
        floorInfo.update();
        document.getElementById("floorInfoBox").addEventListener("click", onFloorInfoClick, false);

    }
}

/*function drawFloorInfoBox() {
    var floorInfo = L.Control.extend({
        options: { position: 'topleft' },

        onAdd: function(map) {
            this._div = L.DomUtil.create('div', 'info');
            this._div.innerHTML = "<h2>'Hover or click to expand'</h2>";
            L.DomEvent.on(this._div, "click", this._click)
            return this._div;
        },

        update: = function (props) {
            this._div.innerHTML = '<h5>Room data</h5>' + (props ?
                '<span style="line-height:100%"><h4>' + props.RoomName + '</h4>' +
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
                '</span>'
                : 'Hover over a room to see info');
        },

        _click: function (e) {
            PageMethods.DrawFloorInfoBox(currentFloorLevel, onSuccess);

            function onSuccess(response, userContext, methodName) {
                callBackMethodsToDraw(response);
            }

            this._div.innerHTML = '<h5>Floor data</h5>' + (props ?
            '<span style="line-height:100%"><h4>' + props.FloorLevel + '</h4>' +
            '<br/><br/><h4>Power Consumption</h4>' +
            '<b>Hardware</b>: ' + props.HardwareConsumption +
            '<br/> <b>Light</b>: ' + props.LightConsumption +
            '<br/> <b>Ventilation</b>: ' + props.VentilationConsumption +
            '<br/> <b>Other</b>: ' + props.OtherConsumption +
            '<br/><b>Total</b>: ' + props.TotalPowerConsumption +
            '<br/><br/><h4>Water Consumption</h4>' +
            '<b>Cold Water</b>: ' + props.ColdWaterConsumption +
            '<b>Hot Water</b>: ' + props.HotWaterConsumption +
            '</span>'
            : 'Hover or click to expand');

            var layer = e.target;

            layer.setStyle({
                weight: 5,
                color: '#666',
                dashArray: '',
                fillOpacity: 0.7
            });

            if (!L.Browser.ie && !L.Browser.opera) {
                layer.bringToFront();
            }

            floorInfo.update(layer.feature.properties);

        },
    });
}*/

function drawRoomInfo() {
    roomInfo.onAdd = function (map) {
        this._div = L.DomUtil.create('div', 'info'); // create a div with a class "info"
        this.update();
        return this._div;
    };

    // method that we will use to update the control based on feature properties passed
    roomInfo.update = function (props) {
        this._div.innerHTML = '<h4>Room data</h4>' + (props ?
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
            '</span>'
            : 'Hover over a room to see info');
    };

    roomInfo.addTo(geoMap);
}

function onEachFeature(feature, layer) {
    layer.on({
        mouseover: highlightFeature,
        mouseout: resetHighlight
    });
    //layer.bindPopup(feature.properties.name);
    if (feature.properties.icon != null) {
        console.log("Draw icon");
    }
}

function highlightFeature(e) {
    var layer = e.target;

    layer.setStyle({
        weight: 5,
        color: '#666',
        dashArray: '',
        fillOpacity: 0.7
    });

    if (!L.Browser.ie && !L.Browser.opera) {
        layer.bringToFront();
    }

    roomInfo.update(layer.feature.properties);
}

function resetHighlight(e) {
    geojson.resetStyle(e.target);
    roomInfo.update();
}