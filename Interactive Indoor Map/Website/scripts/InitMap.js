var geoMap;
var view;
var currentFloorLevel = 1;
var roomArray = new Array;
var colletionOfRoomsOnMap = null;
var roomForegroundLayer = null;
var roomBackgroundLayer = null;
var infoboxDataUpdate = null;
var infoboxUpdate = null;
var infoboxDataCached = null;
var roomLayers = [];
var ActiveViews = [];
var ActiveFloorViews = [];
var linesOnMap = null;
var averageTemporalLineOnMap = null;
var temporalActive = false;

function createWorldMap() {
    //Setup the world map
    var worldMap = L.tileLayer('http://{s}.google.com/vt/lyrs=m&x={x}&y={y}&z={z}', {
        minZoom: 19,
        zoom: 19,
        maxZoom: 20,
        maxNativeZoom: 19,
        subdomains:['mt0','mt1','mt2','mt3'],
        attribution: 'Map data &copy; Google maps</a>'
     });

    return worldMap;
}

function InitLeafletMap(jsonMap) {
    function drawWorldMap() {
        var worldMap = createWorldMap();
        var geojson = L.geoJson(jsonMap);
        initMapSettings(geojson);
        worldMap.addTo(geoMap);
    }
    drawWorldMap();

    function drawRooms() {
        getRoomsAndDrawBackground();
        getRoomsAndDrawRoomsWithRoomOverlays(jsonMap);
    }
    drawRooms();

    function drawButtons() {
        CreateSpatialButtons();
        CreateTemporalButtons();
        TemporalDateRangePicker();
        CreateViewButtons();
        buildingButton.button.click();
    }
    drawButtons();

    drawInfobox();
}

function initMapSettings(geojson) {
    //Finds the div for the map to draw in
    geoMap = L.map('map', {
        zoomControl: false,
        minZoom: 19,
        maxZoom: 20,
        zoom: 19,
        maxNativeZoom: 19
    }).fitBounds(geojson.getBounds());


    //Bug 
    geoMap.zoomOut();

    //Disables zoom and dragging on the map
    geoMap.dragging.disable();

    geoMap.touchZoom.disable();
    geoMap.doubleClickZoom.disable();
    geoMap.scrollWheelZoom.disable();
    geoMap.keyboard.disable();
}