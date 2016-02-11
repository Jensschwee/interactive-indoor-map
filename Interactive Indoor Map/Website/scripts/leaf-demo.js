// See post: http://asmaloney.com/2014/01/code/creating-an-interactive-map-with-leaflet-and-openstreetmap/

function leafletDraw() {
    var map = L.tileLayer('http://{s}.mqcdn.com/tiles/1.0.0/map/{z}/{x}/{y}.png', {
        center: [55.36698307259987, 10.430810451507568],
        minZoom: 2,
        zoom: 18,
        subdomains: ['otile1', 'otile2', 'otile3', 'otile4']
    });
    //PageMethods.LoadJSON()
    //"map/map.json"
    $.getJSON("map/map.json", function (data) {
        var geojson = L.geoJson(data, {
            onEachFeature: function (feature, layer) {
                layer.bindPopup(feature.properties.name);
                layer.setStyle({
                    fillColor: feature.properties.fill,
                    weight: 1,
                    fillOpacity: 0.8
                });
            }
        });

        var GeoMap = L.map('map').fitBounds(geojson.getBounds());
        map.addTo(GeoMap);
        geojson.addTo(GeoMap);
    });
}

