"use strict";
class DefaultView extends View{
    constructor() {

        var style = function style(feature) {
            return {
                fillColor: 'green',
                color: 'white',
                weight: 1,
                opacity: 1,
                fillOpacity: 1
            };
        };

        super(style,null,null,null);
        super.drawView();
    }
}