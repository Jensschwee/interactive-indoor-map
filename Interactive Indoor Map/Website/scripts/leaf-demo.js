// See post: http://asmaloney.com/2014/01/code/creating-an-interactive-map-with-leaflet-and-openstreetmap/
var buildingInfo = L.Control({ position: 'topright' });
var floorInfo = L.Control({ position: 'topright' });
var roomInfo = L.control();
var geojson;
var geoMap;

function leafletDraw(JSONMap) {

    //Setup the world map
    var worldMap = L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
        minZoom: 19,
        zoom: 19,
        maxZoom: 19,
        attribution: 'Map data &copy; <a href="http://openstreetmap.org">OpenStreetMap</a>'
    });

    //Reads the JSON input
    geojson = L.geoJson(JSONMap, {
        style: style,
        onEachFeature: onEachFeature
    });

    //Fints the div for the map to draw in
    geoMap = L.map('map', {
        zoomControl: false,
        minZoom: 19,
        zoom: 19,
        maxZoom: 19,
    }).fitBounds(geojson.getBounds());

    L.control.fullscreen({
        position: 'bottomleft'
    }).addTo(geoMap);
    //https://github.com/brunob/leaflet.fullscreen
    

    L.easyButton('-1;', function () {
        if (geoMap != null) {
            geoMap.removeLayer(geojson);
        }

        PageMethods.DrawFloor(-1, onSuccess);
        function onSuccess(response, userContext, methodName) {
            DrawTemp(response);
        }
    }, { position: 'bottomleft' }).addTo(geoMap);

    L.easyButton('0;', function () {
        if (geoMap != null) {
            geoMap.removeLayer(geojson);
        }

        PageMethods.DrawFloor(0, onSuccess);
        function onSuccess(response, userContext, methodName) {
            DrawTemp(response);
        }
    }, { position: 'bottomleft' }).addTo(geoMap);
    L.easyButton('1;', function () {
        if (geoMap != null) {
            geoMap.removeLayer(geojson);
        }

        PageMethods.DrawFloor(1, onSuccess);
        function onSuccess(response, userContext, methodName) {
            DrawTemp(response);
        }
    }, { position: 'bottomleft' }).addTo(geoMap);
    L.easyButton('2;', function () {
        if (geoMap != null) {
            geoMap.removeLayer(geojson);
        }

        PageMethods.DrawFloor(2, onSuccess);
        function onSuccess(response, userContext, methodName) {
            DrawTemp(response);
        }
    }, { position: 'bottomleft' }).addTo(geoMap);

    //Adds the two maps to the div
    geojson.addTo(geoMap);
    worldMap.addTo(geoMap);

    //Disableds zoom and dragging on the map
    geoMap.dragging.disable();
    geoMap.touchZoom.disable();
    geoMap.doubleClickZoom.disable();
    geoMap.scrollWheelZoom.disable();
    geoMap.keyboard.disable();

    var legend = L.control({ position: 'bottomright' });

    legend.onAdd = function (map) {

        var div = L.DomUtil.create('div', 'info legend'),
            grades = [24, 23.5, 23, 22.5, 22, 21.5, 21, 20.5, 20],
            labels = [];

        // loop through our density intervals and generate a label with a colored square for each interval
        for (var i = 0; i < grades.length; i++) {
            div.innerHTML +=
                '<i style="background:' + getColor(grades[i]) + '"></i> ' +
                //(grades[i + 1] ? '' : '-') +
                //(grades[i - 1] ? '' : '+') +
                grades[i] + (grades[i + 1] ? '&#8451' + '<br>' : '&#8451');
            //'<i style="background:' + getColor(grades[i] + 1) + '"></i> ' +
            //grades[i] + (grades[i + 1] ? '&ndash;' + grades[i + 1] + '<br>' : '+');
        }

        return div;
    };

    legend.addTo(geoMap);

    roomInfo.onAdd = function (map) {
        this._div = L.DomUtil.create('div', 'info'); // create a div with a class "info"
        this.update();
        return this._div;
    };

    // method that we will use to update the control based on feature properties passed
    roomInfo.update = function (props) {
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

function style(feature) {
    return {
        fillColor: getColor(feature.properties.Temperature), //getPower(feature.properties.power),
        color: 'white',//feature.properties.stroke,
        weight: 1,
        opacity: 1,
        fillOpacity: 1
    };
}

function getColor(d) {
    return d >= 24 ? '#800026' :
           d >= 23.5 ? '#FC4E2A' :
           d >= 23 ? '#FD8D3C' :
           d >= 22.5 ? '#FEB24C' :
           d >= 22 ? '#FED976' :
           d >= 21.5 ? '#A4D98B' :
           d >= 21 ? '#6FA375' :
           d >= 20.5 ? '#577BB5' :
           d >= 20 ? '#264E5C' :
                      '#264E5C';
    //return d > 24 ? '#800026' :
    //       d > 23.5 ? '#800026' :
    //       d > 23 ? '#800026' :
    //       d > 22.5 ? '#BD0026' :
    //       d > 22 ? '#E31A1C' :
    //       d > 21.5 ? '#FC4E2A' :
    //       d > 21 ? '#FD8D3C' :
    //       d > 20.5 ? '#FEB24C' :
    //       d > 20 ? '#FED976' :
    //                  '#FFEDA0';
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


function DrawTemp(JSONMap) {

    geojson = L.geoJson(jQuery.parseJSON(JSONMap), {
        style: style,
        onEachFeature: onEachFeature
    });

    geoMap.addLayer(geojson);

}
