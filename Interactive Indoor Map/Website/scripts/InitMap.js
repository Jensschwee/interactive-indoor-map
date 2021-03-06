﻿var geoMap;
var view;
var currentFloorLevel = 1;
var roomArray = new Array;
var colletionOfRoomsOnMap = null;
var roomForegroundLayer = null;
var roomBackgroundLayer = null;
var infoboxUpdate = null;
var roomLayers = [];
var ActiveViews = [];
var ActiveFloorViews = [];
var linesOnMap = null;
var linesMinMaxOnMap = null;
var temporalActive = false;



function DrawWorldMap() {
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

    var worldMap = DrawWorldMap();

    //Reads the JSON input
    var geojson = L.geoJson(jsonMap);
    initMapSettings(geojson);

    getRoomsAndDrawBackground();
    getRoomsAndDrawRoomsWithRoomOverlays();

    worldMap.addTo(geoMap);


    CreateSpatialButtons();
    CreateTemporalButtons();
    TemporalDateRangePicker();
    CreateViewButtons();
    buildingButton.button.click();

    createInfoBox();
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

function addLevel0() {
    var json = {
        "type": "FeatureCollection",
        "crs": {
            "type": "name",
            "properties": {
                "name": "urn:ogc:def:crs:OGC:1.3:CRS84"
            }
        },
        "features": [
          //Level 0
          {
              "type": "Feature",
              "properties": {
                  "RoomId": "Ø20-606-0",
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.430841441, 55.366968517],
                      [10.430653052, 55.3669603690001],
                      [10.430635802, 55.367089175],
                      [10.430824193, 55.367097324],
                      [10.430841441, 55.366968517]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "RoomId": "Ø20-510a-0",
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4307638240001, 55.3675481390001],
                      [10.4305754280001, 55.3675399900001],
                      [10.430566803, 55.367604392],
                      [10.4305581780001, 55.3676687940001],
                      [10.4307465750001, 55.367676943],
                      [10.4307552, 55.367612541],
                      [10.4307638240001, 55.3675481390001]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "RoomId": "Ø22-606c-0",
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4311268000001, 55.366980862],
                      [10.430940122, 55.3669727860001],
                      [10.430922874, 55.3671015880001],
                      [10.43110955, 55.367109665],
                      [10.4311268000001, 55.366980862]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "RoomId": "Ø22-508-0",
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4310491750001, 55.367560482],
                      [10.4308625030001, 55.3675524080001],
                      [10.430853879, 55.3676168100001],
                      [10.4308452550001, 55.367681212],
                      [10.4310319250001, 55.367689286],
                      [10.43104055, 55.3676248840001],
                      [10.4310491750001, 55.367560482]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "RoomId": "Ø21-600b-0",
                  "Class": "Corridor",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4307825390001, 55.3674083780001],
                      [10.4308812190001, 55.367412646],
                      [10.430904049, 55.3672421620001],
                      [10.430805369, 55.367237894],
                      [10.4307825390001, 55.3674083780001]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Stairs",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4308402840001, 55.367718331],
                      [10.430853879, 55.3676168100001],
                      [10.4308597040001, 55.3675733090001],
                      [10.430761025, 55.3675690410001],
                      [10.4307552, 55.367612541],
                      [10.430741604, 55.3677140630001],
                      [10.4307452240001, 55.36771422],
                      [10.4307456060001, 55.367711367],
                      [10.430835319, 55.367715247],
                      [10.430834937, 55.3677181],
                      [10.4308402840001, 55.367718331]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "RoomId": "Ø20-508a-0",
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.430691509, 55.3676745610001],
                      [10.4306326560001, 55.367672015],
                      [10.4306276840001, 55.367709135],
                      [10.430686537, 55.3677116810001],
                      [10.430691509, 55.3676745610001]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.430602322, 55.367670703],
                      [10.4305581780001, 55.3676687940001],
                      [10.4305532070001, 55.3677059140001],
                      [10.43059735, 55.367707823],
                      [10.430602322, 55.367670703]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4306326560001, 55.367672015],
                      [10.430602322, 55.367670703],
                      [10.43059735, 55.367707823],
                      [10.4306276840001, 55.367709135],
                      [10.4306326560001, 55.367672015]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4307163440001, 55.3676917650001],
                      [10.43071352, 55.3677128480001],
                      [10.430741604, 55.3677140630001],
                      [10.430744427, 55.3676929800001],
                      [10.4307163440001, 55.3676917650001]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4306893610001, 55.3676905980001],
                      [10.430744427, 55.3676929800001],
                      [10.4307465750001, 55.367676943],
                      [10.430691509, 55.3676745610001],
                      [10.4306893610001, 55.3676905980001]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4307163440001, 55.3676917650001],
                      [10.4306893610001, 55.3676905980001],
                      [10.430686537, 55.3677116810001],
                      [10.43071352, 55.3677128480001],
                      [10.4307163440001, 55.3676917650001]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4310319250001, 55.367689286],
                      [10.4308452550001, 55.367681212],
                      [10.4308402840001, 55.367718331],
                      [10.4310269540001, 55.367726406],
                      [10.4310319250001, 55.367689286]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "RoomId": "Ø22-511-0",
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4310578000001, 55.3674960800001],
                      [10.430871127, 55.367488006],
                      [10.4308625030001, 55.3675524080001],
                      [10.4310491750001, 55.367560482],
                      [10.4310578000001, 55.3674960800001]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "RoomId": "Ø22-512-0",
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.431066425, 55.3674316780001],
                      [10.4308797510001, 55.3674236040001],
                      [10.430871127, 55.367488006],
                      [10.4310578000001, 55.3674960800001],
                      [10.431066425, 55.3674316780001]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "RoomId": "Ø22-600b-0",
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.43107259, 55.3673856410001],
                      [10.430885916, 55.3673775670001],
                      [10.4308797510001, 55.3674236040001],
                      [10.431066425, 55.3674316780001],
                      [10.43107259, 55.3673856410001]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4310753820001, 55.3673647910001],
                      [10.4308887080001, 55.3673567170001],
                      [10.430885916, 55.3673775670001],
                      [10.43107259, 55.3673856410001],
                      [10.4310753820001, 55.3673647910001]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "RoomId": "Ø20-511-0",
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4305754280001, 55.3675399900001],
                      [10.4307638240001, 55.3675481390001],
                      [10.430772448, 55.367483737],
                      [10.4305840530001, 55.367475588],
                      [10.4305754280001, 55.3675399900001]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "RoomId": "Ø20-512c-0",
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4307828560001, 55.367406014],
                      [10.430594462, 55.367397866],
                      [10.4305840530001, 55.367475588],
                      [10.430772448, 55.367483737],
                      [10.4307828560001, 55.367406014]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4307470690001, 55.3673929660001],
                      [10.4305959930001, 55.367386432],
                      [10.430594462, 55.367397866],
                      [10.4307455370001, 55.3674044000001],
                      [10.430745819, 55.367404412],
                      [10.43074735, 55.3673929780001],
                      [10.4307470690001, 55.3673929660001]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4307858550001, 55.3673836180001],
                      [10.430748818, 55.3673820160001],
                      [10.43074735, 55.3673929780001],
                      [10.430745819, 55.367404412],
                      [10.4307828560001, 55.367406014],
                      [10.4307843870001, 55.3673945800001],
                      [10.4307858550001, 55.3673836180001]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "RoomId": "Ø20-600b-0",
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.430749239, 55.367376757],
                      [10.4305981640001, 55.3673702230001],
                      [10.4305959930001, 55.367386432],
                      [10.4307470690001, 55.3673929660001],
                      [10.43074735, 55.3673929780001],
                      [10.4307495210001, 55.367376769],
                      [10.430749239, 55.367376757]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4306317480001, 55.367357392],
                      [10.4306000660001, 55.367356021],
                      [10.4305981640001, 55.3673702230001],
                      [10.430629846, 55.3673715940001],
                      [10.4306317480001, 55.367357392]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "RoomId": "Ø20-600a-0",
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4306000660001, 55.367356021],
                      [10.43078846, 55.3673641670001],
                      [10.4307900260001, 55.3673524720001],
                      [10.430601632, 55.367344324],
                      [10.4306000660001, 55.367356021]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.43078846, 55.3673641670001],
                      [10.4307514230001, 55.3673625660001],
                      [10.4307495210001, 55.367376769],
                      [10.430748818, 55.3673820160001],
                      [10.4307858550001, 55.3673836180001],
                      [10.430786558, 55.367378371],
                      [10.43078846, 55.3673641670001]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.430727328, 55.367361524],
                      [10.430725427, 55.3673757270001],
                      [10.4307495210001, 55.367376769],
                      [10.4307514230001, 55.3673625660001],
                      [10.430727328, 55.367361524]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.430703409, 55.3673604900001],
                      [10.430701508, 55.367374693],
                      [10.430725427, 55.3673757270001],
                      [10.430727328, 55.367361524],
                      [10.430703409, 55.3673604900001]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4306795100001, 55.3673594570001],
                      [10.430677609, 55.3673736590001],
                      [10.430701508, 55.367374693],
                      [10.430703409, 55.3673604900001],
                      [10.4306795100001, 55.3673594570001]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.430655662, 55.3673584260001],
                      [10.43065376, 55.3673726280001],
                      [10.430677609, 55.3673736590001],
                      [10.4306795100001, 55.3673594570001],
                      [10.430655662, 55.3673584260001]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4306317480001, 55.367357392],
                      [10.430629846, 55.3673715940001],
                      [10.43065376, 55.3673726280001],
                      [10.430655662, 55.3673584260001],
                      [10.4306317480001, 55.367357392]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Corridor",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.430797985, 55.3672930370001],
                      [10.4306095920001, 55.367284888],
                      [10.430601632, 55.367344324],
                      [10.4307900260001, 55.3673524720001],
                      [10.430797985, 55.3672930370001]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Corridor",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4309637490001, 55.3673000050001],
                      [10.43096074, 55.367322476],
                      [10.430908013, 55.367320196],
                      [10.430911023, 55.3672977250001],
                      [10.430896691, 55.367297105],
                      [10.4308887080001, 55.3673567170001],
                      [10.4310753820001, 55.3673647910001],
                      [10.4310833660001, 55.367305179],
                      [10.4309637490001, 55.3673000050001]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "RoomId": "Ø22-603-0",
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4308994830001, 55.367276254],
                      [10.431086158, 55.367284328],
                      [10.4311009250001, 55.367174069],
                      [10.4309142490001, 55.3671659950001],
                      [10.4308994830001, 55.367276254]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.43110955, 55.367109665],
                      [10.430922874, 55.3671015880001],
                      [10.4309142490001, 55.3671659950001],
                      [10.4311009250001, 55.367174069],
                      [10.43110955, 55.367109665]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "RoomId": "Ø20-603-0",
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.430612384, 55.367264042],
                      [10.4308007770001, 55.3672721890001],
                      [10.4308127080001, 55.367183089],
                      [10.4306243130001, 55.3671749660001],
                      [10.430612384, 55.367264042]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "RoomId": "Ø20-604-0",
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.430824193, 55.367097324],
                      [10.430635802, 55.367089175],
                      [10.4306243130001, 55.3671749660001],
                      [10.4308127080001, 55.367183089],
                      [10.430824193, 55.367097324]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.430653052, 55.3669603690001],
                      [10.430841441, 55.366968517],
                      [10.4308464120001, 55.366931397],
                      [10.430658023, 55.366923248],
                      [10.430653052, 55.3669603690001]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4309984870001, 55.366937975],
                      [10.4309935160001, 55.366975096],
                      [10.431051871, 55.3669776200001],
                      [10.431056842, 55.3669404990001],
                      [10.4309984870001, 55.366937975]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.431087452, 55.366941823],
                      [10.43108248, 55.366978944],
                      [10.4311268000001, 55.366980862],
                      [10.431131771, 55.3669437400001],
                      [10.431087452, 55.366941823]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.431087452, 55.366941823],
                      [10.431056842, 55.3669404990001],
                      [10.431051871, 55.3669776200001],
                      [10.43108248, 55.366978944],
                      [10.431087452, 55.366941823]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.430971389, 55.366936803],
                      [10.4309685700001, 55.366957853],
                      [10.430995668, 55.366959025],
                      [10.4309984870001, 55.366937975],
                      [10.430971389, 55.366936803]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.430995668, 55.366959025],
                      [10.4309422740001, 55.3669567160001],
                      [10.430940122, 55.3669727860001],
                      [10.4309935160001, 55.366975096],
                      [10.430995668, 55.366959025]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.430971389, 55.366936803],
                      [10.430945093, 55.3669356660001],
                      [10.4309422740001, 55.3669567160001],
                      [10.4309685700001, 55.366957853],
                      [10.430971389, 55.366936803]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Stairs",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4308271200001, 55.367075464],
                      [10.4309258010001, 55.367079732],
                      [10.430945093, 55.3669356660001],
                      [10.4309397540001, 55.3669354350001],
                      [10.4309393720001, 55.366938288],
                      [10.430849659, 55.366934407],
                      [10.430850041, 55.3669315540001],
                      [10.4308464120001, 55.366931397],
                      [10.4308271200001, 55.367075464]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Elevator",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4309637490001, 55.3673000050001],
                      [10.430911023, 55.3672977250001],
                      [10.430908013, 55.367320196],
                      [10.43096074, 55.367322476],
                      [10.4309637490001, 55.3673000050001]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "RoomId": "Ø22-601b-0",
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.431086158, 55.367284328],
                      [10.4308994830001, 55.367276254],
                      [10.430896691, 55.367297105],
                      [10.4310833660001, 55.367305179],
                      [10.431086158, 55.367284328]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Corridor",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.430805369, 55.367237894],
                      [10.430904049, 55.3672421620001],
                      [10.4309258010001, 55.367079732],
                      [10.4308271200001, 55.367075464],
                      [10.430805369, 55.367237894]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "RoomId": "Ø20-601b-0",
                  "Class": "Room",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4308007770001, 55.3672721890001],
                      [10.430612384, 55.367264042],
                      [10.4306095920001, 55.367284888],
                      [10.430797985, 55.3672930370001],
                      [10.4308007770001, 55.3672721890001]
                    ]
                  ]
              }
          },
          {
              "type": "Feature",
              "properties": {
                  "Class": "Corridor",
                  "ZLevel": 0,
                  "AccessLeve": "Public",
                  "VenueId": "01 Campus",
                  "VenueName": "Campusvej"
              },
              "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [10.4308812190001, 55.367412646],
                      [10.4307825390001, 55.3674083780001],
                      [10.430761025, 55.3675690410001],
                      [10.4308597040001, 55.3675733090001],
                      [10.4308812190001, 55.367412646]
                    ]
                  ]
              }
          }]
    };

    L.geoJson(json, {
        onEachFeature: function(feature, layer) {
            layer.bindPopup(feature.properties.RoomId + " " + feature.geometry.coordinates);
        }
    }).addTo(geoMap);
}

function addLevel1() {
    var json = {
        "type": "FeatureCollection",
        "crs": {
            "type": "name",
            "properties": {
                "name": "urn:ogc:def:crs:OGC:1.3:CRS84"
            }
        },
        "features": [
            //Level 1

    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.43077966, 55.367405983],
                [10.430594447, 55.367397972],
                [10.430584067, 55.3674754790001],
                [10.43076928, 55.36748349],
                [10.43077966, 55.367405983]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø21-511b-1",
            "Class": "Corridor",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430835212, 55.367715242],
                [10.4308398060001, 55.367680927],
                [10.4308842190001, 55.3676828480001],
                [10.4309014460001, 55.367554225],
                [10.430723347, 55.3675465210001],
                [10.4307061420001, 55.367674987],
                [10.430750275, 55.367676896],
                [10.430745659, 55.3677113690001],
                [10.430835212, 55.367715242]
              ],
              [
                [10.430858947, 55.367574189],
                [10.4308475240001, 55.3676595090001],
                [10.4307486020001, 55.3676552300001],
                [10.4307600280001, 55.36756991],
                [10.430858947, 55.367574189]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4310319320001, 55.367689237],
                [10.4308398060001, 55.367680927],
                [10.430835212, 55.367715242],
                [10.430835319, 55.367715247],
                [10.430834937, 55.3677181],
                [10.4310269540001, 55.367726406],
                [10.4310319320001, 55.367689237]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4307163710001, 55.367692021],
                [10.4307135810001, 55.3677128510001],
                [10.4307452240001, 55.36771422],
                [10.4307456060001, 55.367711367],
                [10.430745659, 55.3677113690001],
                [10.430748066, 55.367693392],
                [10.4307163710001, 55.367692021]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4306023350001, 55.3676704980001],
                [10.4305582060001, 55.3676685890001],
                [10.4305532070001, 55.3677059140001],
                [10.4305973370001, 55.367707823],
                [10.4306023350001, 55.3676704980001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430632616, 55.3676718080001],
                [10.4306023350001, 55.3676704980001],
                [10.4305973370001, 55.367707823],
                [10.4306276180001, 55.3677091330001],
                [10.430632616, 55.3676718080001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-508a-1",
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4306861150001, 55.3677116630001],
                [10.4306889050001, 55.367690833],
                [10.4306969680001, 55.367691182],
                [10.4306991780001, 55.367674687],
                [10.4306911140001, 55.367674338],
                [10.430632616, 55.3676718080001],
                [10.4306276180001, 55.3677091330001],
                [10.4306861150001, 55.3677116630001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4306991780001, 55.367674687],
                [10.4306969680001, 55.367691182],
                [10.430748066, 55.367693392],
                [10.430750275, 55.367676896],
                [10.4306991780001, 55.367674687]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4307163710001, 55.367692021],
                [10.4306889050001, 55.367690833],
                [10.4306861150001, 55.3677116630001],
                [10.4307135810001, 55.3677128510001],
                [10.4307163710001, 55.367692021]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-510-1",
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430723347, 55.3675465210001],
                [10.4305754100001, 55.367540122],
                [10.4305582060001, 55.3676685890001],
                [10.4307061420001, 55.367674987],
                [10.430723347, 55.3675465210001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-603-1",
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4311009210001, 55.3671740930001],
                [10.43091481, 55.3671660420001],
                [10.4308999900001, 55.367276712],
                [10.4310861000001, 55.3672847620001],
                [10.4311009210001, 55.3671740930001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-511-1",
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.43076928, 55.36748349],
                [10.430584067, 55.3674754790001],
                [10.4305754100001, 55.367540122],
                [10.430760623, 55.3675481330001],
                [10.43076928, 55.36748349]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-511-1",
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.431057781, 55.3674962250001],
                [10.4308716730001, 55.3674881760001],
                [10.4308630510001, 55.3675525640001],
                [10.4310491580001, 55.3675606140001],
                [10.431057781, 55.3674962250001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø21-600c-1",
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.431072543, 55.3673859940001],
                [10.4308864340001, 55.3673779440001],
                [10.4308716730001, 55.3674881760001],
                [10.431057781, 55.3674962250001],
                [10.431072543, 55.3673859940001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-601b-1",
            "Class": "Corridor",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4310844660001, 55.3672969610001],
                [10.4308983560001, 55.3672889100001],
                [10.43089724, 55.3672972480001],
                [10.430911, 55.3672978430001],
                [10.430911109, 55.367297029],
                [10.430963816, 55.367299309],
                [10.4309607220001, 55.367322421],
                [10.430908013, 55.367320142],
                [10.4309081230001, 55.3673193230001],
                [10.430894364, 55.367318728],
                [10.4308880140001, 55.367366148],
                [10.431074123, 55.3673741980001],
                [10.4310844660001, 55.3672969610001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-606c-1",
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4309793780001, 55.366974462],
                [10.430962113, 55.3671033680001],
                [10.431109539, 55.3671097450001],
                [10.431126803, 55.3669808390001],
                [10.4309793780001, 55.366974462]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4309985950001, 55.36693798],
                [10.430993627, 55.3669750780001],
                [10.4310522440001, 55.3669776130001],
                [10.431057212, 55.3669405150001],
                [10.4309985950001, 55.36693798]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4310876060001, 55.36694183],
                [10.431082638, 55.366978928],
                [10.431126803, 55.3669808390001],
                [10.431131771, 55.3669437400001],
                [10.4310876060001, 55.36694183]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.431057212, 55.3669405150001],
                [10.4310522440001, 55.3669776130001],
                [10.431082638, 55.366978928],
                [10.4310876060001, 55.36694183],
                [10.431057212, 55.3669405150001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430971625, 55.3669368130001],
                [10.4309688120001, 55.366957819],
                [10.430995782, 55.366958986],
                [10.4309985950001, 55.36693798],
                [10.430971625, 55.3669368130001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4309880170001, 55.3669586500001],
                [10.4309428440001, 55.366956696],
                [10.4309406890001, 55.3669727880001],
                [10.4309858620001, 55.3669747420001],
                [10.4309880170001, 55.3669586500001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430971625, 55.3669368130001],
                [10.4309456570001, 55.36693569],
                [10.4309428440001, 55.366956696],
                [10.4309688120001, 55.366957819],
                [10.430971625, 55.3669368130001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4309880170001, 55.3669586500001],
                [10.4309858620001, 55.3669747420001],
                [10.430993627, 55.3669750780001],
                [10.430995782, 55.366958986],
                [10.4309880170001, 55.3669586500001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4306530480001, 55.366960399],
                [10.4308382580001, 55.36696841],
                [10.4308432330001, 55.3669312590001],
                [10.430658023, 55.366923248],
                [10.4306530480001, 55.366960399]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-606-1",
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430801009, 55.3669667990001],
                [10.4306530480001, 55.366960399],
                [10.4306357890001, 55.3670892740001],
                [10.43078375, 55.367095674],
                [10.430801009, 55.3669667990001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-604b-1",
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430624295, 55.3671750980001],
                [10.430809507, 55.3671831080001],
                [10.430821, 55.3670972850001],
                [10.4306357890001, 55.3670892740001],
                [10.430624295, 55.3671750980001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4306123600001, 55.367264219],
                [10.4307975720001, 55.36727223],
                [10.430809507, 55.3671831080001],
                [10.430624295, 55.3671750980001],
                [10.4306123600001, 55.367264219]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-601b-1",
            "Class": "Corridor",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430795946, 55.3672843740001],
                [10.430610734, 55.367276363],
                [10.430600079, 55.367355918],
                [10.4307852920001, 55.3673639290001],
                [10.430795946, 55.3672843740001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4307498270001, 55.3673768830001],
                [10.43059815, 55.367370323],
                [10.4305960070001, 55.367386325],
                [10.430747684, 55.3673928850001],
                [10.4307498270001, 55.3673768830001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430747684, 55.3673928850001],
                [10.4305960070001, 55.367386325],
                [10.430594447, 55.367397972],
                [10.4307461240001, 55.3674045320001],
                [10.430747684, 55.3673928850001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430749119, 55.3673821690001],
                [10.430782655, 55.3673836190001],
                [10.4307852920001, 55.3673639290001],
                [10.4307517560001, 55.3673624780001],
                [10.430749119, 55.3673821690001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430782655, 55.3673836190001],
                [10.430749119, 55.3673821690001],
                [10.430747684, 55.3673928850001],
                [10.4307461240001, 55.3674045320001],
                [10.43077966, 55.367405983],
                [10.43078122, 55.3673943360001],
                [10.430782655, 55.3673836190001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-600a-1",
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4307273920001, 55.3673614240001],
                [10.430725463, 55.3673758290001],
                [10.4307498270001, 55.3673768830001],
                [10.4307517560001, 55.3673624780001],
                [10.4307273920001, 55.3673614240001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4306317460001, 55.3673572880001],
                [10.430600079, 55.367355918],
                [10.43059815, 55.367370323],
                [10.4306298170001, 55.3673716930001],
                [10.4306317460001, 55.3673572880001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4306557310001, 55.3673583250001],
                [10.4306317460001, 55.3673572880001],
                [10.4306298170001, 55.3673716930001],
                [10.4306538010001, 55.3673727300001],
                [10.4306557310001, 55.3673583250001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430679624, 55.367359358],
                [10.4306557310001, 55.3673583250001],
                [10.4306538010001, 55.3673727300001],
                [10.430677695, 55.367373763],
                [10.430679624, 55.367359358]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430703653, 55.367360397],
                [10.430679624, 55.367359358],
                [10.430677695, 55.367373763],
                [10.4307017240001, 55.367374802],
                [10.430703653, 55.367360397]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4307273920001, 55.3673614240001],
                [10.430703653, 55.367360397],
                [10.4307017240001, 55.367374802],
                [10.430725463, 55.3673758290001],
                [10.4307273920001, 55.3673614240001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-510-1",
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4309014460001, 55.367554225],
                [10.4308842190001, 55.3676828480001],
                [10.4310319320001, 55.367689237],
                [10.4310491580001, 55.3675606140001],
                [10.4309014460001, 55.367554225]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430858947, 55.367574189],
                [10.4307600280001, 55.36756991],
                [10.4307486020001, 55.3676552300001],
                [10.4308475240001, 55.3676595090001],
                [10.430858947, 55.367574189]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.43091481, 55.3671660420001],
                [10.4311009210001, 55.3671740930001],
                [10.431109539, 55.3671097450001],
                [10.430923427, 55.367101694],
                [10.43091481, 55.3671660420001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Elevator",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430963816, 55.367299309],
                [10.430911109, 55.367297029],
                [10.430908013, 55.367320142],
                [10.4309607220001, 55.367322421],
                [10.430963816, 55.367299309]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø21-602-1",
            "Class": "Corridor",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4309046290001, 55.3672420730001],
                [10.430923427, 55.367101694],
                [10.430962113, 55.3671033680001],
                [10.4309793780001, 55.366974462],
                [10.4309406890001, 55.3669727880001],
                [10.4309456570001, 55.36693569],
                [10.4309397540001, 55.3669354350001],
                [10.4309393720001, 55.366938288],
                [10.430849659, 55.366934407],
                [10.430850041, 55.3669315540001],
                [10.4308432330001, 55.3669312590001],
                [10.4308382580001, 55.36696841],
                [10.430801009, 55.3669667990001],
                [10.43078375, 55.367095674],
                [10.430820999, 55.3670972850001],
                [10.430802203, 55.3672376430001],
                [10.4309046290001, 55.3672420730001]
              ],
              [
                [10.430823977, 55.367075051],
                [10.4308353340001, 55.3669902400001],
                [10.4309377590001, 55.3669946700001],
                [10.4309264020001, 55.3670794810001],
                [10.430823977, 55.367075051]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Corridor",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430881862, 55.367412089],
                [10.430779435, 55.367407659],
                [10.430760623, 55.3675481330001],
                [10.4308630510001, 55.3675525640001],
                [10.430881862, 55.367412089]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø21-606-1",
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4308239760001, 55.367075051],
                [10.4309264020001, 55.3670794810001],
                [10.4309377590001, 55.3669946700001],
                [10.4308353340001, 55.3669902400001],
                [10.4308239760001, 55.367075051]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-601b-1",
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.431074123, 55.3673741980001],
                [10.4308880140001, 55.367366148],
                [10.4308864340001, 55.3673779440001],
                [10.431072543, 55.3673859940001],
                [10.431074123, 55.3673741980001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-601b-1",
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4308983560001, 55.3672889100001],
                [10.4310844660001, 55.3672969610001],
                [10.4310861000001, 55.3672847620001],
                [10.4308999900001, 55.367276712],
                [10.4308983560001, 55.3672889100001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-601b-1",
            "Class": "Room",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430610734, 55.367276363],
                [10.430795946, 55.3672843740001],
                [10.4307975720001, 55.36727223],
                [10.4306123600001, 55.367264219],
                [10.430610734, 55.367276363]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø21-600b-1",
            "Class": "Lobby",
            "ZLevel": 1,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430802204, 55.3672376430001],
                [10.4307975720001, 55.36727223],
                [10.430795946, 55.3672843740001],
                [10.4307852920001, 55.3673639290001],
                [10.430782655, 55.3673836190001],
                [10.43078122, 55.3673943360001],
                [10.43077966, 55.367405983],
                [10.430779435, 55.367407659],
                [10.430881862, 55.367412089],
                [10.4308864340001, 55.3673779440001],
                [10.4308880140001, 55.367366148],
                [10.430894364, 55.367318728],
                [10.4309081230001, 55.3673193230001],
                [10.430911, 55.3672978430001],
                [10.43089724, 55.3672972480001],
                [10.430898357, 55.3672889100001],
                [10.4308999900001, 55.367276712],
                [10.4309046290001, 55.3672420730001],
                [10.430802204, 55.3672376430001]
              ]
            ]
        }
    }
        ]
    };
    L.geoJson(json, {
        onEachFeature: function (feature, layer) {
            layer.bindPopup(feature.properties.RoomId + " " + feature.geometry.coordinates);
        }
    }).addTo(geoMap);

}

function addLevel2() {
    var json = {
        "type": "FeatureCollection",
        "crs": {
            "type": "name",
            "properties": {
                "name": "urn:ogc:def:crs:OGC:1.3:CRS84"
            }
        },
        "features": [
            //Level 2
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4310381780001, 55.3670208350001],
                [10.431120967, 55.367024416],
                [10.4311239310001, 55.3670022840001],
                [10.431041141, 55.366998703],
                [10.4310381780001, 55.3670208350001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-508e-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.43084306, 55.3676811170001],
                [10.4308380900001, 55.367718236],
                [10.4310269540001, 55.367726406],
                [10.4310319250001, 55.367689286],
                [10.43084306, 55.3676811170001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-509c-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4306525000001, 55.367586267],
                [10.430569711, 55.3675826780001],
                [10.430566803, 55.3676043930001],
                [10.4306495930001, 55.3676079740001],
                [10.4306525000001, 55.367586267]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4309303950001, 55.367598371],
                [10.4308545800001, 55.367595092],
                [10.4308516840001, 55.3676167150001],
                [10.4309274990001, 55.3676199940001],
                [10.4309303950001, 55.367598371]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430749948, 55.3676553390001],
                [10.430845956, 55.367659491],
                [10.4308574190001, 55.367573887],
                [10.430761411, 55.367569734],
                [10.430749948, 55.3676553390001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430691525, 55.367674562],
                [10.4306326760001, 55.3676720170001],
                [10.4306277050001, 55.3677091370001],
                [10.430686554, 55.367711682],
                [10.430691525, 55.367674562]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4306026080001, 55.3676707170001],
                [10.4305581780001, 55.367668795],
                [10.4305532070001, 55.3677059140001],
                [10.4305976370001, 55.3677078360001],
                [10.4306026080001, 55.3676707170001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-508a-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4306326760001, 55.3676720170001],
                [10.4306026080001, 55.3676707170001],
                [10.4305976370001, 55.3677078360001],
                [10.4306277050001, 55.3677091370001],
                [10.4306326760001, 55.3676720170001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4307165930001, 55.3676917270001],
                [10.430713762, 55.3677128590001],
                [10.4307420810001, 55.3677140840001],
                [10.430744911, 55.367692952],
                [10.4307165930001, 55.3676917270001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-508e-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4306893840001, 55.3676905500001],
                [10.430744911, 55.367692952],
                [10.4307470520001, 55.3676769640001],
                [10.430691525, 55.367674562],
                [10.4306893840001, 55.3676905500001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4307165930001, 55.3676917270001],
                [10.4306893840001, 55.3676905500001],
                [10.430686554, 55.367711682],
                [10.430713762, 55.3677128590001],
                [10.4307165930001, 55.3676917270001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430758548, 55.367591114],
                [10.430682921, 55.3675878430001],
                [10.430680049, 55.3676092910001],
                [10.430755676, 55.367612562],
                [10.430758548, 55.367591114]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-508d-2",
            "Class": "Corridor",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430720922, 55.3675679830001],
                [10.4307238110001, 55.3675464090001],
                [10.4306884210001, 55.367544878],
                [10.430691305, 55.3675233320001],
                [10.430661061, 55.367522024],
                [10.4306581770001, 55.3675435700001],
                [10.4306582180001, 55.367543572],
                [10.430655329, 55.3675651460001],
                [10.4306409660001, 55.367672376],
                [10.4306714250001, 55.367673693],
                [10.4307470520001, 55.3676769640001],
                [10.430749948, 55.3676553390001],
                [10.430674321, 55.367652068],
                [10.430685784, 55.3675664630001],
                [10.430720922, 55.3675679830001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-508-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4307528050001, 55.3676340010001],
                [10.4306771780001, 55.3676307310001],
                [10.430674321, 55.367652068],
                [10.430749948, 55.3676553390001],
                [10.4307528050001, 55.3676340010001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-509d-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430755676, 55.367612562],
                [10.430680049, 55.3676092910001],
                [10.4306771780001, 55.3676307310001],
                [10.4307528050001, 55.3676340010001],
                [10.430755676, 55.367612562]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-510c-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430682921, 55.3675878430001],
                [10.430758548, 55.367591114],
                [10.430761411, 55.367569734],
                [10.430685784, 55.3675664630001],
                [10.430682921, 55.3675878430001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-508c-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430643843, 55.3676508990001],
                [10.4305610540001, 55.3676473180001],
                [10.4305581780001, 55.367668795],
                [10.4306409660001, 55.367672376],
                [10.430643843, 55.3676508990001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-509a-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4306467220001, 55.3676294050001],
                [10.4305639340001, 55.367625816],
                [10.4305610540001, 55.3676473180001],
                [10.430643843, 55.3676508990001],
                [10.4306467220001, 55.3676294050001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-509b-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4306495930001, 55.3676079740001],
                [10.430566803, 55.3676043930001],
                [10.4305639340001, 55.367625816],
                [10.4306467220001, 55.3676294050001],
                [10.4306495930001, 55.3676079740001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-510a-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430569711, 55.3675826780001],
                [10.4306525000001, 55.367586267],
                [10.430655329, 55.3675651460001],
                [10.430572539, 55.3675615650001],
                [10.430569711, 55.3675826780001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430647293, 55.3670033700001],
                [10.4307300840001, 55.3670069510001],
                [10.4307330180001, 55.3669850370001],
                [10.430650228, 55.3669814570001],
                [10.430647293, 55.3670033700001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430653052, 55.3669603700001],
                [10.430842091, 55.3669685460001],
                [10.4308470620001, 55.3669314250001],
                [10.430658023, 55.366923248],
                [10.430653052, 55.3669603700001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-606-2",
            "Class": "Corridor",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4307459550001, 55.367115685],
                [10.430748851, 55.3670940640001],
                [10.4307842320001, 55.3670955950001],
                [10.4307870810001, 55.367074309],
                [10.430751609, 55.3670727740001],
                [10.4307631830001, 55.3669863420001],
                [10.4308392670001, 55.3669896330001],
                [10.430842091, 55.3669685460001],
                [10.430735842, 55.3669639510001],
                [10.4307330180001, 55.3669850380001],
                [10.430721444, 55.36707147],
                [10.430718594, 55.367092756],
                [10.4307156990001, 55.3671143770001],
                [10.4307459550001, 55.367115685]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4306582180001, 55.367543572],
                [10.4305754280001, 55.3675399910001],
                [10.430572539, 55.3675615650001],
                [10.4306553280001, 55.3675651460001],
                [10.4306582180001, 55.367543572]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430691305, 55.3675233320001],
                [10.4306884210001, 55.367544878],
                [10.4307644730001, 55.3675481670001],
                [10.430767358, 55.36752662],
                [10.430691305, 55.3675233320001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430661061, 55.367522024],
                [10.4305783130001, 55.3675184460001],
                [10.4305754280001, 55.3675399910001],
                [10.4306581770001, 55.3675435700001],
                [10.430661061, 55.367522024]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø21-600b-2",
            "Class": "Corridor",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430925523, 55.3670798140001],
                [10.430827757, 55.3670755860001],
                [10.4307832860001, 55.3674076780001],
                [10.4308810520001, 55.367411906],
                [10.4308935670001, 55.3673184530001],
                [10.4309081650001, 55.367319084],
                [10.430910996, 55.3672979460001],
                [10.430896397, 55.367297314],
                [10.430925523, 55.3670798140001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-511-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430773097, 55.367483765],
                [10.4305840530001, 55.367475589],
                [10.4305783130001, 55.3675184460001],
                [10.430767358, 55.36752662],
                [10.430773097, 55.367483765]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430783557, 55.3674056510001],
                [10.4305945140001, 55.367397474],
                [10.4305840530001, 55.367475589],
                [10.430773097, 55.367483765],
                [10.430783557, 55.3674056510001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430747433, 55.3673926760001],
                [10.4305960340001, 55.367386127],
                [10.4305945140001, 55.367397474],
                [10.4307459140001, 55.3674040230001],
                [10.430747433, 55.3673926760001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4307865070001, 55.3673836290001],
                [10.430748866, 55.3673820010001],
                [10.430747433, 55.3673926760001],
                [10.4307459140001, 55.3674040230001],
                [10.430783557, 55.3674056510001],
                [10.4307850770001, 55.3673943040001],
                [10.4307865070001, 55.3673836290001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430749565, 55.3673767920001],
                [10.430598161, 55.367370243],
                [10.4305960340001, 55.367386127],
                [10.430747433, 55.3673926760001],
                [10.430749565, 55.3673767920001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430748866, 55.3673820010001],
                [10.4307865070001, 55.3673836290001],
                [10.4307891510001, 55.367363884],
                [10.430751517, 55.367362256],
                [10.430748866, 55.3673820010001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-600b-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4307275040001, 55.367361218],
                [10.4307255580001, 55.3673757540001],
                [10.430749565, 55.3673767920001],
                [10.430751517, 55.367362256],
                [10.4307275040001, 55.367361218]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4306318000001, 55.367357079],
                [10.430600108, 55.367355708],
                [10.430598161, 55.367370243],
                [10.4306298540001, 55.367371614],
                [10.4306318000001, 55.367357079]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.43065583, 55.367358118],
                [10.4306318000001, 55.367357079],
                [10.4306298540001, 55.367371614],
                [10.430653884, 55.3673726530001],
                [10.43065583, 55.367358118]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-600a-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430679641, 55.367359148],
                [10.43065583, 55.367358118],
                [10.430653884, 55.3673726530001],
                [10.4306776940001, 55.367373683],
                [10.430679641, 55.367359148]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4307036490001, 55.367360186],
                [10.430679641, 55.367359148],
                [10.4306776940001, 55.367373683],
                [10.4307017030001, 55.3673747220001],
                [10.4307036490001, 55.367360186]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4307275040001, 55.367361218],
                [10.4307036490001, 55.367360186],
                [10.4307017030001, 55.3673747220001],
                [10.4307255580001, 55.3673757540001],
                [10.4307275040001, 55.367361218]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-601b-2",
            "Class": "Corridor",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430601639, 55.3673442720001],
                [10.4307906820001, 55.3673524490001],
                [10.430798619, 55.3672931850001],
                [10.4306095760001, 55.3672850090001],
                [10.430601639, 55.3673442720001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-603c-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4308162180001, 55.3671617540001],
                [10.4306271780001, 55.3671535780001],
                [10.43061241, 55.367263849],
                [10.430801452, 55.3672720260001],
                [10.4308162180001, 55.3671617540001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-604a-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430821947, 55.3671189720001],
                [10.4306329070001, 55.3671107960001],
                [10.4306271780001, 55.3671535780001],
                [10.4308162180001, 55.3671617540001],
                [10.430821947, 55.3671189720001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-604b-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430718594, 55.367092755],
                [10.430635802, 55.367089175],
                [10.4306329070001, 55.3671107960001],
                [10.4307156990001, 55.3671143770001],
                [10.430718594, 55.367092755]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430760278, 55.367008034],
                [10.430836362, 55.3670113250001],
                [10.4308392670001, 55.3669896330001],
                [10.4307631830001, 55.3669863420001],
                [10.430760278, 55.367008034]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-605a-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4307243220001, 55.3670499780001],
                [10.430641531, 55.367046396],
                [10.4306386530001, 55.3670678890001],
                [10.430721444, 55.3670714690001],
                [10.4307243220001, 55.3670499780001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-605b-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4307272180001, 55.3670283530001],
                [10.4306444270001, 55.367024772],
                [10.430641531, 55.367046396],
                [10.4307243220001, 55.3670499780001],
                [10.4307272180001, 55.3670283530001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-605c-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4307300840001, 55.3670069510001],
                [10.430647293, 55.3670033700001],
                [10.4306444270001, 55.367024772],
                [10.4307272180001, 55.3670283530001],
                [10.4307300840001, 55.3670069510001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-605e-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430830612, 55.3670542620001],
                [10.4307545290001, 55.36705097],
                [10.430751609, 55.3670727740001],
                [10.430827692, 55.367076065],
                [10.430830612, 55.3670542620001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-605d-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430833466, 55.3670329490001],
                [10.4307573830001, 55.367029658],
                [10.4307545290001, 55.36705097],
                [10.430830612, 55.3670542620001],
                [10.430833466, 55.3670329490001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430836362, 55.3670113250001],
                [10.430760278, 55.367008034],
                [10.4307573830001, 55.367029658],
                [10.430833466, 55.3670329490001],
                [10.430836362, 55.3670113250001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-604c-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430721444, 55.36707147],
                [10.4306386530001, 55.3670678890001],
                [10.430635802, 55.367089175],
                [10.430718594, 55.367092756],
                [10.430721444, 55.36707147]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-604d-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4307870810001, 55.367074309],
                [10.4307842320001, 55.3670955950001],
                [10.430824842, 55.367097351],
                [10.430827692, 55.367076065],
                [10.4307870810001, 55.367074309]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-604e-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430748851, 55.3670940640001],
                [10.4307459550001, 55.367115685],
                [10.430821947, 55.3671189720001],
                [10.430824842, 55.367097351],
                [10.430748851, 55.3670940640001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-509c-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.431043446, 55.3676032610001],
                [10.43096058, 55.3675996760001],
                [10.4309576840001, 55.3676213000001],
                [10.43104055, 55.3676248840001],
                [10.431043446, 55.3676032610001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Corridor",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4309332350001, 55.367577166],
                [10.430918874, 55.3676843960001],
                [10.4309490590001, 55.3676857020001],
                [10.430963419, 55.367578472],
                [10.4309332350001, 55.367577166]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-508b-2",
            "Class": "Corridor",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430921778, 55.367662711],
                [10.4308459640001, 55.367659432],
                [10.43084306, 55.3676811170001],
                [10.430918874, 55.3676843960001],
                [10.430921778, 55.367662711]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-509a-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4309246450001, 55.3676413050001],
                [10.4308488300001, 55.3676380260001],
                [10.4308459640001, 55.367659432],
                [10.430921778, 55.367662711],
                [10.4309246450001, 55.3676413050001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-509b-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4309274990001, 55.3676199940001],
                [10.4308516840001, 55.3676167150001],
                [10.4308488300001, 55.3676380260001],
                [10.4309246450001, 55.3676413050001],
                [10.4309274990001, 55.3676199940001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-510c-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4308545800001, 55.367595092],
                [10.4309303950001, 55.367598371],
                [10.4309332350001, 55.367577166],
                [10.4308574190001, 55.367573887],
                [10.4308545800001, 55.367595092]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-508c-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.431034821, 55.3676676630001],
                [10.4309519550001, 55.3676640780001],
                [10.4309490590001, 55.3676857020001],
                [10.4310319250001, 55.367689286],
                [10.431034821, 55.3676676630001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-509e-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.431037696, 55.3676461950001],
                [10.4309548300001, 55.3676426100001],
                [10.4309519550001, 55.3676640780001],
                [10.431034821, 55.3676676630001],
                [10.431037696, 55.3676461950001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-509d-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.43104055, 55.3676248840001],
                [10.4309576840001, 55.3676213000001],
                [10.4309548300001, 55.3676426100001],
                [10.431037696, 55.3676461950001],
                [10.43104055, 55.3676248840001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-510a-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.43096058, 55.3675996760001],
                [10.431043446, 55.3676032610001],
                [10.431046286, 55.3675820560001],
                [10.430963419, 55.367578472],
                [10.43096058, 55.3675996760001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-510b-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.43096639, 55.3675569010001],
                [10.4309635000001, 55.3675784750001],
                [10.431046286, 55.3675820560001],
                [10.4310491750001, 55.367560482],
                [10.43096639, 55.3675569010001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-508-2",
            "Class": "Corridor",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.43096639, 55.3675569010001],
                [10.430969286, 55.367535278],
                [10.430938998, 55.367533968],
                [10.430936103, 55.367555591],
                [10.4309010150001, 55.3675540730001],
                [10.430898127, 55.3675756480001],
                [10.4309635000001, 55.3675784750001],
                [10.43096639, 55.3675569010001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430865135, 55.3675307730001],
                [10.4310520710001, 55.367538859],
                [10.4310578000001, 55.3674960810001],
                [10.4308708630001, 55.367487995],
                [10.430865135, 55.3675307730001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430938998, 55.367533968],
                [10.430865135, 55.3675307730001],
                [10.430862239, 55.3675523960001],
                [10.430936103, 55.367555591],
                [10.430938998, 55.367533968]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430969286, 55.367535278],
                [10.43096639, 55.3675569010001],
                [10.4310491750001, 55.367560482],
                [10.4310520710001, 55.367538859],
                [10.430969286, 55.367535278]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-511-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4310725510001, 55.3673859370001],
                [10.430885613, 55.3673778510001],
                [10.4308708630001, 55.367487995],
                [10.4310578000001, 55.3674960810001],
                [10.4310725510001, 55.3673859370001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Corridor",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430887274, 55.367365449],
                [10.4310742120001, 55.3673735340001],
                [10.431084528, 55.3672965040001],
                [10.4308975880001, 55.367288418],
                [10.430896397, 55.367297314],
                [10.430910996, 55.3672979460001],
                [10.4309111310001, 55.3672969400001],
                [10.4309638570001, 55.3672992210001],
                [10.430960742, 55.3673224780001],
                [10.430908016, 55.367320197],
                [10.4309081650001, 55.367319084],
                [10.4308935670001, 55.3673184530001],
                [10.430893418, 55.367319566],
                [10.430887274, 55.367365449]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-601b-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4311009250001, 55.367174069],
                [10.430913984, 55.3671659830001],
                [10.430899213, 55.367276288],
                [10.431086153, 55.3672843740001],
                [10.4311009250001, 55.367174069]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-604e-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.431106696, 55.367130978],
                [10.4309197540001, 55.3671228920001],
                [10.430913984, 55.3671659830001],
                [10.4311009250001, 55.367174069],
                [10.431106696, 55.367130978]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-604a-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430996726, 55.3671047870001],
                [10.4309226080001, 55.367101581],
                [10.4309197540001, 55.3671228920001],
                [10.430993872, 55.367126098],
                [10.430996726, 55.3671047870001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-604d-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4310267650001, 55.367106086],
                [10.43102391, 55.367127397],
                [10.431106696, 55.367130978],
                [10.43110955, 55.367109666],
                [10.4310267650001, 55.367106086]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4310876160001, 55.36694183],
                [10.4310826440001, 55.3669789520001],
                [10.4311268000001, 55.366980862],
                [10.431131771, 55.3669437400001],
                [10.4310876160001, 55.36694183]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4309714770001, 55.3669368070001],
                [10.4309686720001, 55.36695775],
                [10.430996045, 55.3669589340001],
                [10.43099885, 55.366937991],
                [10.4309714770001, 55.3669368070001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4310575640001, 55.3669405300001],
                [10.43099885, 55.366937991],
                [10.430993879, 55.3669751130001],
                [10.4310525930001, 55.3669776520001],
                [10.4310575640001, 55.3669405300001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4310876160001, 55.36694183],
                [10.4310575640001, 55.3669405300001],
                [10.4310525930001, 55.3669776520001],
                [10.4310826440001, 55.3669789520001],
                [10.4310876160001, 55.36694183]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430996045, 55.3669589340001],
                [10.4309420230001, 55.3669565980001],
                [10.4309398570001, 55.3669727760001],
                [10.430993879, 55.3669751130001],
                [10.430996045, 55.3669589340001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4309714770001, 55.3669368070001],
                [10.4309448280001, 55.366935654],
                [10.4309420230001, 55.3669565980001],
                [10.4309686720001, 55.36695775],
                [10.4309714770001, 55.3669368070001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-604b-2",
            "Class": "Corridor",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.431026764, 55.367106086],
                [10.431041141, 55.366998703],
                [10.431041303, 55.3669987100001],
                [10.4310441710001, 55.366977288],
                [10.4309398570001, 55.3669727760001],
                [10.430936988, 55.366994199],
                [10.431011105, 55.3669974040001],
                [10.430999641, 55.3670830200001],
                [10.4309639580001, 55.3670814770001],
                [10.430961043, 55.3671032440001],
                [10.430996726, 55.3671047870001],
                [10.430994986, 55.367117776],
                [10.430993872, 55.367126098],
                [10.43102391, 55.367127397],
                [10.4310249970001, 55.3671192830001],
                [10.431026764, 55.367106086]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4310441710001, 55.366977288],
                [10.431041303, 55.3669987100001],
                [10.4311239310001, 55.3670022840001],
                [10.4311268000001, 55.366980862],
                [10.4310441710001, 55.366977288]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4309340250001, 55.3670163300001],
                [10.4310081420001, 55.3670195350001],
                [10.431011105, 55.3669974040001],
                [10.430936988, 55.366994199],
                [10.4309340250001, 55.3670163300001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-604c-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.431112446, 55.3670880430001],
                [10.431029659, 55.367084462],
                [10.431026764, 55.367106086],
                [10.43110955, 55.367109666],
                [10.431112446, 55.3670880430001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-605e-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.431115305, 55.3670666940001],
                [10.4310325170001, 55.367063113],
                [10.431029659, 55.367084462],
                [10.431112446, 55.3670880430001],
                [10.431115305, 55.3670666940001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-605d-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4311181750001, 55.3670452640001],
                [10.4310353860001, 55.3670416830001],
                [10.4310325170001, 55.367063113],
                [10.431115305, 55.3670666940001],
                [10.4311181750001, 55.3670452640001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4309639580001, 55.3670814770001],
                [10.430925523, 55.3670798140001],
                [10.4309226080001, 55.367101581],
                [10.430961043, 55.3671032440001],
                [10.4309639580001, 55.3670814770001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-605a-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4310024820001, 55.367061806],
                [10.4309283640001, 55.3670586000001],
                [10.430925523, 55.3670798140001],
                [10.430999641, 55.3670830200001],
                [10.4310024820001, 55.367061806]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø22-605b-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.43100535, 55.3670403840001],
                [10.430931233, 55.367037178],
                [10.4309283640001, 55.3670586000001],
                [10.4310024820001, 55.367061806],
                [10.43100535, 55.3670403840001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Corridor",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430845956, 55.367659491],
                [10.430749948, 55.3676553390001],
                [10.4307470520001, 55.3676769640001],
                [10.43084306, 55.3676811170001],
                [10.430845956, 55.367659491]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Corridor",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.43084306, 55.3676811170001],
                [10.4307470520001, 55.3676769640001],
                [10.4307420810001, 55.3677140840001],
                [10.4307452240001, 55.36771422],
                [10.4307456060001, 55.367711367],
                [10.430835319, 55.367715247],
                [10.430834937, 55.3677181],
                [10.4308380900001, 55.367718236],
                [10.43084306, 55.3676811170001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø21-511-2",
            "Class": "Corridor",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4308810520001, 55.367411906],
                [10.4307832860001, 55.3674076780001],
                [10.4307644730001, 55.3675481670001],
                [10.4307238110001, 55.3675464090001],
                [10.430720922, 55.3675679830001],
                [10.430761584, 55.3675697420001],
                [10.430898127, 55.3675756480001],
                [10.4309010150001, 55.3675540730001],
                [10.430862239, 55.3675523960001],
                [10.4308810520001, 55.367411906]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Elevator",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4309638570001, 55.3672992210001],
                [10.4309111310001, 55.3672969400001],
                [10.430908016, 55.367320197],
                [10.430960742, 55.3673224780001],
                [10.4309638570001, 55.3672992210001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Corridor",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430839222, 55.3669899700001],
                [10.430936988, 55.366994199],
                [10.4309448280001, 55.366935654],
                [10.4309397540001, 55.3669354350001],
                [10.4309393720001, 55.366938288],
                [10.430849659, 55.366934407],
                [10.430850041, 55.3669315540001],
                [10.4308470620001, 55.3669314250001],
                [10.430839222, 55.3669899700001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø21-606-2",
            "Class": "Corridor",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430827757, 55.3670755860001],
                [10.430925523, 55.3670798140001],
                [10.430936988, 55.366994199],
                [10.430839222, 55.3669899700001],
                [10.430827757, 55.3670755860001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.430735842, 55.3669639510001],
                [10.430653052, 55.3669603700001],
                [10.430650228, 55.3669814570001],
                [10.4307330180001, 55.3669850380001],
                [10.430735842, 55.3669639510001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.431120967, 55.367024416],
                [10.4310381780001, 55.3670208350001],
                [10.4310353860001, 55.3670416830001],
                [10.4311181750001, 55.3670452640001],
                [10.431120967, 55.367024416]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4310081420001, 55.3670195350001],
                [10.4309340250001, 55.3670163300001],
                [10.430931233, 55.367037178],
                [10.43100535, 55.3670403840001],
                [10.4310081420001, 55.3670195350001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4308975880001, 55.367288418],
                [10.431084528, 55.3672965040001],
                [10.431086153, 55.3672843740001],
                [10.430899213, 55.367276288],
                [10.4308975880001, 55.367288418]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4310742120001, 55.3673735340001],
                [10.430887274, 55.367365449],
                [10.430885613, 55.3673778510001],
                [10.4310725510001, 55.3673859370001],
                [10.4310742120001, 55.3673735340001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-601b-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4306095760001, 55.3672850090001],
                [10.430798619, 55.3672931850001],
                [10.430801452, 55.3672720260001],
                [10.43061241, 55.367263849],
                [10.4306095760001, 55.3672850090001]
              ]
            ]
        }
    },
    {
        "type": "Feature",
        "properties": {
            "RoomId": "Ø20-601b-2",
            "Class": "Room",
            "ZLevel": 2,
            "AccessLeve": "Public",
            "VenueId": "01 Campus",
            "VenueName": "Campusvej"
        },
        "geometry": {
            "type": "Polygon",
            "coordinates": [
              [
                [10.4307906820001, 55.3673524490001],
                [10.430601639, 55.3673442720001],
                [10.430600108, 55.367355708],
                [10.4307891510001, 55.367363884],
                [10.4307906820001, 55.3673524490001]
              ]
            ]
        }
    }
        ]
    };
    L.geoJson(json, {
        onEachFeature: function(feature, layer) {
            layer.bindPopup(feature.properties.RoomId + " " + feature.geometry.coordinates);
        }
    }).addTo(geoMap);

}