function TemperatureView() {
    var style = function style(feature) {
        return {
            fillColor: roomColor(feature.properties.Temperature), //getPower(feature.properties.power),
            color: 'white', //feature.properties.stroke,
            weight: 1,
            opacity: 1,
            fillOpacity: 1
        };
    };

    var roomColor = function getRoomColor(d) {
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
    };

    var siUnit = '&#8451';

    var sensorValues = [24, 23.5, 23, 22.5, 22, 21.5, 21, 20.5, 20];

    return View.call(this, style, roomColor, siUnit, sensorValues);
}