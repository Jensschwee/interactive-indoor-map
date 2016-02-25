﻿var buildingInfo = L.Control({ position: 'topright' });
var floorInfo = L.Control({ position: 'topright' });
var roomInfo = L.control();

function drawRoomInfo(geoMap) {
    roomInfo.onAdd = function(map) {
        this._div = L.DomUtil.create('div', 'info'); // create a div with a class "info"
        this.update();
        return this._div;
    };

    // method that we will use to update the control based on feature properties passed
    roomInfo.update = function(props) {
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
            '<br/><b>Total</b>: ' + props.TotalConsumption +
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