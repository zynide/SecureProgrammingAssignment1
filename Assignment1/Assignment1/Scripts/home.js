var HomeModel = function () {
    var self = this;
    self.file = ko.observable();
    self.UploadFile = function () {
        var files = document.getElementById('files').files;
        var selectedFile = files[0];
        var reader = new FileReader();
        var fileString;
        var testString = "test\n";
        reader.readAsBinaryString(selectedFile);


        reader.onloadend = function (evt) {
            console.log("now executing onloadend");
            //if (evt.target.readyState == FileReader.DONE) { // DONE == 2
            //    fileString = evt.target.result;
            //    //console.log(fileString + " fileString");
            //    //self.sendFileToServer(fileString);
            //    console.log(testString);
            //    console.log(fileString);
            //    $.ajax({
            //        url: '/Home/UploadFile',
            //        type: 'POST',
            //        data: { file: fileString },
            //        dataType: 'json',
            //        success: function (json) {
            //            console.log("upload successful");
            //        }
            //    });
            //}
        };
        self.sendFileToServer = function (fileRequired) {
            console.log(fileRequired);
            $.ajax({
                url: '/Home/UploadFile',
                type: 'POST',
                data: { file: fileRequired },
                dataType: 'json',
                success: function (json) {
                    console.log("upload successful");
                }
            });
        };
    };

    self.CreateUploader = function (elementID, buttonText, imageCategory, imageIndex) {
        var uploader = new qq.FineUploader({
            element: document.getElementById(elementID),
            request: {
                endpoint: '/Home/UploadFile',
                params: {
                    'test': "test"
                }
            },
            validation: {
                acceptFiles: 'image/*, application/pdf',
                allowedExtensions: ['pdf', 'tif', 'tiff', 'bmp', 'png', 'gif', 'jpeg', 'jpg'],
                sizeLimit: 204800000 // 200 MB = 200,000 * 1024 bytes
            },
            text: {
                uploadButton: buttonText
            },
            template: '<pre ><span>{dragZoneText}</span></pre>' +
            '<input type="hidden" id="' + imageCategory + 'Input"></input>' +
            '<input type="file"  data-input="false" data-icon="false" data-buttontext="Upload" id="filestyle-' + imageIndex + '" style="position: absolute; left: -9999px;">' +
            '<div id="summaryUpload" >{uploadButtonText}</div>' +
            '<ul  style="margin-top: 3px; margin-right: 10px; float: right; display:inline-block; text-align: center;"></ul>',
            classes: {
                retryable: 'false',
                success: 'alert alert-success',
                fail: 'alert alert-error'
            },
            callbacks: {
                onSubmit: function (id, fileName, responseJSON) {
                    console.log("this shit worked");
                }
            },
            debug: true
        });
    };

}

var homeModel = new HomeModel();

ko.applyBindings(homeModel);
