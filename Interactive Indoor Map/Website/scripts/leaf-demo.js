// See post: http://asmaloney.com/2014/01/code/creating-an-interactive-map-with-leaflet-and-openstreetmap/
function leafletDraw(JSONMap) {

    //Setup the world map
    var worldMap = L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
        center: [55.366983072599, 10.4308104515075],
        minZoom: 19,
        zoom: 19,
        maxZoom: 19
    });


    //Reads the JSON input
    var geojson = L.geoJson(JSONMap, {
            style: style,
            onEachFeature: function (feature, layer) {
                layer.bindPopup(feature.properties.name);
                if (feature.properties.icon != null) {
                    console.log("Draw icon");
                }
            }
    });
   
    //Fints the div for the map to draw in
    var geoMap = L.map('map').fitBounds(geojson.getBounds());

    //Adds the two maps to the div
    geojson.addTo(geoMap);
    worldMap.addTo(geoMap);

    //Disableds zoom and dragging on the map
    geoMap.dragging.disable();
    geoMap.touchZoom.disable();
    geoMap.doubleClickZoom.disable();
    geoMap.scrollWheelZoom.disable();

}

function style(feature) {
    return {
        fillColor: feature.properties.fill, //getPower(feature.properties.power),
        color: 'white',//feature.properties.stroke,
        weight: 1,
        opacity: 1,
        fillOpacity: 1
    };
}

