var uri = "";
if (window.location.port == "" && window.location.host != "localhost") {
    uri += window.location.protocol + "//" + window.location.hostname;
    if (window.location.pathname.split('/').length > 3) {
        for (var i = 0; i < window.location.pathname.split('/').length - 3; i++) {
            uri += "/" + window.location.pathname.split('/')[i + 1];
        }
    }
}
else if (window.location.port == "" && window.location.host == "localhost") {
    uri = window.location.protocol + "//" + window.location.hostname + "/" + window.location.pathname.split('/')[1];
}
else {
    uri = window.location.protocol + "//" + window.location.hostname + ":" + window.location.port;
    if (window.location.pathname.split('/').length > 3) {
        for (var i = 0; i < window.location.pathname.split('/').length - 3; i++) {
            uri += "/" + window.location.pathname.split('/')[i + 1];
        }
    }
}