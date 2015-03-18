var HomeModel = function () {
    var self = this;
    self.file = ko.observable();

}

// Activates knockout.js
ko.applyBindings(new HomeModel());