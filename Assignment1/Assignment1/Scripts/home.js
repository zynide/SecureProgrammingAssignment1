document.getElementById("uploadBtn").onchange = function () {
    console.log(this);
    document.getElementById("uploadFile").value = this.files[0].name;
};



var HomeModel = function () {
    var self = this;

    self.OutputFilePath = ko.observable();
    self.Message = ko.observable($("#Message").val());
    self.DownloadOutputFile = function () {
        window.location.href = "/Download/OutputFileDownload";
    };

    self.SetTextBox = function () {
        var xmlhttp = new XMLHttpRequest();
        var url = "/CPP/outputFile.xml";
        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                $("#textbox").text(xmlhttp.responseText);
            }
        }
        xmlhttp.open("GET", url, true);
        xmlhttp.send();
    };
    self.IsFileReady = function () {
        $.ajax({
            url: '/Home/WaitForFile',
            type: 'POST',
            dataType: 'json',
            success: function (json) {
                console.log(json);
                self.SetTextBox();
            }
        });
    };

    if (self.Message() != "") {
        self.IsFileReady();
    }
}

var homeModel = new HomeModel();

ko.applyBindings(homeModel);