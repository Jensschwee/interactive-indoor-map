var geojson;
var geoMap;
var callBackMethodsToDraw;

var legend;

function DrawWorldMap() {
    //Setup the world map
    var worldMap = L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
        minZoom: 19,
        zoom: 19,
        maxZoom: 19,
        attribution: 'Map data &copy; <a href="http://openstreetmap.org">OpenStreetMap</a>'
    });

    return worldMap;
}

function InitLeafletMap(JSONMap) {draw

    var worldMap = DrawWorldMap();

    function style(feature) {
        return {
            fillColor: 'blue',
            color: 'white',//feature.properties.stroke,
            weight: 1,
            opacity: 1,
            fillOpacity: 1
        };
    }


    //Reads the JSON input
    geojson = L.geoJson(JSONMap, {
        style: style,
        onEachFeature: onEachFeature
    });

    initMapSettings();


    //Adds the two maps to the div
    geojson.addTo(geoMap);
    worldMap.addTo(geoMap);

    drawRoomInfo(geoMap);


    function drawGeoJsonMap(JSONMap) {
        geojson = L.geoJson(jQuery.parseJSON(JSONMap), {
            onEachFeature: onEachFeature,
            style: style
        });
        geoMap.addLayer(geojson);
    }

    callBackMethodsToDraw = drawGeoJsonMap;

    CreateButtons();
}

function initMapSettings() {
    //Finds the div for the map to draw in
    geoMap = L.map('map', {
        zoomControl: false,
        minZoom: 19,
        zoom: 19,
        maxZoom: 19,
    }).fitBounds(geojson.getBounds());

    //Disables zoom and dragging on the map
    geoMap.dragging.disable();
    geoMap.touchZoom.disable();
    geoMap.doubleClickZoom.disable();
    geoMap.scrollWheelZoom.disable();
    geoMap.keyboard.disable();
}