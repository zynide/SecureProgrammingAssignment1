var HomeModel = function () {
    var self = this;
    self.file = ko.observable();

}

var homeModel = new HomeModel();

ko.applyBindings(homeModel);
