function DefaultView() {
    var style = function style(feature) {
        return {
            fillColor: 'green',
            color: 'white',
            weight: 1,
            opacity: 1,
            fillOpacity: 1
        };
    };
    return View.call(this, style);
}