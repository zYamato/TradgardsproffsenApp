function initialize() {
    var latlng = new google.maps.LatLng(59.247235326961594, 15.214773749819738);
    var options = {
        zoom: 6, center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("map"), options);
}