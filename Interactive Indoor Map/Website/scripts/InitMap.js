var geoMap;
var view;
var currentFloorLevel = 0;
var roomArray = new Array;
var colletionOfRoomsOnMap = null;
var roomBackgrundLayer = null;
var ActiveViews = [];
//    Views: [],
//    ActiveViews: ActiveViews.Views.length
//    //,
//    //Temperature: false,
//    //TemperatureColor: "#8ab1c4",
//    //CO2: false,
//    //CO2Color: "#c7b7ea", //#9b59b6
//    //Light: false,
//    //LightColor: "#ffe11d", //#fce30b
//    //HardwareConsumption: false,
//    //HardWareConsumptionColor: "#f83e2d",
//    //LightConsumption: false,
//    //LightConsumptionColor: "#fe4e35",
//    //VentilationConsumption: false,
//    //VentilationConsumptionColor: "#d15258",
//    //OtherConsumption: false,
//    //OtherConsumptionColor: "#ff8289",
//    //TotalPowerConsumption: false,
//    //TotalPowerConsumptionColor: "#e74c3c",
//    //Motion: false,
//    //MotionColor: "#b2d649",
//    //Occupants: false,
//    //OccupantsColor: "#2ecc71",
//    //WifiClients: false,
//    //WifiClientsColor: "#83bd1a"
//    ////"#2ecc71"
//    ////#d6f58e
//};


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
    //DefaultView.prototype = new View();
    //TemperatureView.prototype = new View();
    getRoomsAndDrawRooms();

    worldMap.addTo(geoMap);

    createInfoBox();

    CreateSpatialButtons();
    CreateViewButtons();
    //drawRoomsBackgrund(JSONMap);
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