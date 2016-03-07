var geoMap;
var view;
var currentFloorLevel = 0;

function DrawWorldMap() {
    //Setup the world map
    var worldMap = L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
        minZoom: 19,
        zoom: 19,
        maxZoom: 20,
        maxNativeZoom: 19,
        attribution: 'Map data &copy; <a href="http://openstreetmap.org">OpenStreetMap</a>'
    });

    return worldMap;
}

function InitLeafletMap(JSONMap) {

    var worldMap = DrawWorldMap();

    //Reads the JSON input
    var geojson = L.geoJson(JSONMap);
    initMapSettings(geojson);

    //Links obj to super obj
    DefaultView.prototype = new View();
    TemperatureView.prototype = new View();

    view = new DefaultView();

    view.drawView();

    worldMap.addTo(geoMap);

    drawRoomInfo(geoMap);

    CreateButtons();

}

function initMapSettings(geojson) {
    //Finds the div for the map to draw in
    geoMap = L.map('map', {
        //zoomControl: false,
        minZoom: 19,
        zoom: 20,
        maxZoom: 20,
        maxNativeZoom: 19
    }).fitBounds(geojson.getBounds());

    //Disables zoom and dragging on the map
    geoMap.dragging.disable();

    geoMap.touchZoom.disable();
    geoMap.doubleClickZoom.disable();
    geoMap.scrollWheelZoom.disable();
    geoMap.keyboard.disable();
}