(function () {
    "use strict"
    angular.module("fsmapp")
         .controller("homecontroller",
            ["$rootScope", "$document", "$scope", "$uibModal", "appSettings", "loginservice", "userProfile","ChatService",
    function ($rootScope, $document, $scope, $uibModal, appSettings, loginservice, userProfile, ChatService) {
        $scope.homeurl = appSettings.serverPath;
        $scope.dataLoggedIn = {};
        $scope.isLoggedIn = false;
        $scope.userName = "";
        $scope.FulluserName = "";
        $scope.ulrimage = "";
        $scope.access_token = "";
        $scope.roleName = "";
        $scope.viewwwin = false;
        getdataUser();
        
        $scope.Chats = ChatService;
        //$scope.Notification = 
        //$scope.Chats.onConnected();
        function getdataUser() {
            var data = userProfile.getProfile();
            if (data.isLoggedIn) {
                $scope.isLoggedIn = data.isLoggedIn;
                $scope.userName = data.username;
                $scope.access_token = data.access_token;
                $scope.roleName = data.roleName;
                $scope.viewwwin = $scope.roleName != 'Docgia';
                var datae = userProfile.getProfileExten();
                $scope.FulluserName = datae.fileusername;
                if (datae.ulrimage != null && datae.ulrimage != '') {
                    $scope.ulrimage = appSettings.serverPath + datae.ulrimage;
                }
                else {
                    $scope.ulrimage = appSettings.serverPath + 'Content/image/user.png';
                }
            }
            else {
               // window.location.href = appSettings.serverPath + appSettings.serverLogin;
            }
        }
        $scope.chuyenthongbao = function (item) {
            if (item.inttype == 1)
                window.location.href = appSettings.serverPath + "Qlkhaithac/xetduyetYeucau?id=" + item.intkey + "&idct=" + item.intkey1;
            else if (item.inttype == 2)
                window.location.href = appSettings.serverPath + "Qlkhaithac/dsycduyettaikhoan";
            else window.location.href = appSettings.serverPath + "Baoquan/qlxuattailieu";
        }
        $scope.logout = function () {
            var respd;
            respd = loginservice.postdata("api/Account/Logout");
            respd.then(function (response) {
                userProfile.clearall();
                window.location.href = appSettings.serverPath + appSettings.serverLogin;
            }, function errorCallback(response) {
                userProfile.clearall();
                window.location.href = appSettings.serverPath + appSettings.serverLogin;
            });

        };
        $scope.hosocanhan = function () {
            var parentElem =
                  angular.element($document[0].querySelector('.main_container'))
            var modalInstance = $uibModal.open({
                animation: true,
                backdrop: 'static',
                ariaLabelledBy: 'modal-title',
                ariaDescribedBy: 'modal-body',
                templateUrl: '_ProfilePopup.html',
                controller: 'hosocanhancontroller',
                controllerAs: '$ctrl',
                size: 'lg',
                appendTo: parentElem,
                resolve: {
                    loginservice: loginservice,
                    userProfile: userProfile,
                    appSettings: appSettings
                }
            });
            modalInstance.result.then(function (c) {
            }, function () {
            });
        }
        $scope.changepass = function () {
            var parentElem =
                  angular.element($document[0].querySelector('.main_container'))
            var modalInstance = $uibModal.open({
                animation: true,
                backdrop: 'static',
                ariaLabelledBy: 'modal-title',
                ariaDescribedBy: 'modal-body',
                templateUrl: '_ChangpassPopup.html',
                controller: 'doimatkhaucontroller',
                controllerAs: '$ctrl',
                //size: 'lg',
                appendTo: parentElem,
                resolve: {
                    loginservice: loginservice,
                    userProfile: userProfile,
                    appSettings: appSettings
                }
            });
            modalInstance.result.then(function (c) {
            }, function () {
            });
        }
        $scope.deleteshopping = function () {
            if (confirm("Bạn có muốn xóa hết tài liệu này ra khỏi yêu cầu?")) {
                userProfile.clearShopingcart();
                $scope.countitem = userProfile.getcountShoping();
                $rootScope.$broadcast('handleBroadcast', 0);
            }
        };
        $scope.countitem = userProfile.getcountShoping();


        $scope.$on('handleBroadcast', function () {
            $scope.countitem = userProfile.getcountShoping();
        });


        $scope.pData = [];
        $scope.idfunction;
        getdatachucnang();
        function getdatachucnang() {
            var respd;
            //respd = loginservice.getdata("api/acountinfo/getuserchucnanggroup");
            //respd.then(function (response) {
            //    $scope.pData = response.data;
            //}, function errorCallback(response) {

            //});
        }

    }])
    .controller("functionmenu",
            ["$rootScope", "$document", "$scope", "$uibModal", "appSettings", "loginservice", "userProfile",
    function ($rootScope, $document, $scope, $uibModal, appSettings, loginservice, userProfile) {
        $scope.loginDuan = "";
        $scope.dataResp = {};
        getduan();
        function getduan() {
            var resp = loginservice.getdata("api/userinfo/getallduan");
            resp.then(function (response) {
                if (response.data != null) {
                    $scope.dataResp = response.data;
                    $scope.loginDuan = userProfile.getsaveitem("projectactive");
                }
            }
            , function errorCallback(response) {

            });
        }
        $scope.$on('handleBroadcast', function () {
            $scope.loginDuan = userProfile.getsaveitem("projectactive");
        });
        $scope.changeproject = function () {
            if ($scope.changeproject)
                $rootScope.$broadcast('handleBroadcast', $scope.changeproject);
        }
        $scope.pData = [];
        $scope.idfunction;
        $scope.onload = function (id) {
            $scope.idfunction = id;
        }
        $scope.pshow = [];
        getdatachucnang();
        function getdatachucnang() {
            var parentElem =
              angular.element($document[0].querySelector('#idfunction'));
            $scope.idfunction = parentElem[0].value;
            var respd;
            //respd = loginservice.postdata("api/acountinfo/getuserchucnang", $.param({ ID: $scope.idfunction }));
            //respd.then(function (response) {
            //    $scope.pData = response.data;
            //}, function errorCallback(response) {

            //});
        }
        $scope.url = window.location.href;
        $scope.activegroup = {};
        $scope.activelink = {};
        gethucnangactive();
        function gethucnangactive() {
            $scope.activegroup[0] = "";
            $scope.activegroup[1] = "";
            $scope.activegroup[2] = "";
            $scope.activegroup[3] = "";
            $scope.activegroup[4] = "";
            $scope.activegroup[5] = "";
            $scope.activegroup[6] = "";
            if ($scope.url.indexOf("/Home") > 0) $scope.activegroup[0] = "active";
            if ($scope.url.indexOf("/Duan") > 0) $scope.activegroup[1] = "active open";
            if ($scope.url.indexOf("/DataInput") > 0) $scope.activegroup[2] = "active open";
            if ($scope.url.indexOf("/Gianhan") > 0) $scope.activegroup[3] = "active open";
            if ($scope.url.indexOf("/Fileso") > 0) $scope.activegroup[4] = "active open";
            if ($scope.url.indexOf("/Kiemduyet") > 0) $scope.activegroup[5] = "active open";
            if ($scope.url.indexOf("/Admin") > 0) $scope.activegroup[6] = "active open";

            if ($scope.url.indexOf("/FunctionFull/gridview?f=Tih5zbib2cI%3d") > 0) { $scope.activelink[0] = "active"; $scope.activegroup[1] = "active open"; }
            if ($scope.url.indexOf("/timeline") > 0) $scope.activelink[1] = "active";
            if ($scope.url.indexOf("/configproject") > 0) $scope.activelink[2] = "active";
            if ($scope.url.indexOf("/DataInput/dsphong") > 0) $scope.activelink[3] = "active";
            if ($scope.url.indexOf("/FunctionFull/gridviewfilter?f=q5Pfq1NO4G6kim7OUdcDEw%3d%3d") > 0) { $scope.activelink[4] = "active"; $scope.activegroup[2] = "active open" }
            if ($scope.url.indexOf("/DataInput/dshoso") > 0) $scope.activelink[5] = "active";
            if ($scope.url.indexOf("/DataInput/dsvanban") > 0) $scope.activelink[6] = "active";
            if ($scope.url.indexOf("/DataInput/importhoso") > 0) $scope.activelink[7] = "active";
            if ($scope.url.indexOf("/DataInput/importvanban") > 0) $scope.activelink[8] = "active";
            if ($scope.url.indexOf("/Gianhan/loggiao") > 0) $scope.activelink[9] = "active";
            if ($scope.url.indexOf("/Gianhan/lognhan") > 0) $scope.activelink[10] = "active";
            if ($scope.url.indexOf("/Gianhan/timhoso") > 0) $scope.activelink[11] = "active";
            if ($scope.url.indexOf("/Fileso/uploadfileso") > 0) $scope.activelink[12] = "active";
            if ($scope.url.indexOf("/Fileso/splitfileso") > 0) $scope.activelink[13] = "active";
            if ($scope.url.indexOf("/Fileso/extractfileso") > 0) $scope.activelink[14] = "active";
            if ($scope.url.indexOf("/Fileso/bugsfileso") > 0) $scope.activelink[15] = "active";
            if ($scope.url.indexOf("/Kiemduyet/checkbienmuc") > 0) $scope.activelink[16] = "active";
            if ($scope.url.indexOf("/Kiemduyet/checkbug") > 0) $scope.activelink[17] = "active";
            if ($scope.url.indexOf("/Kiemduyet/permitdoc") > 0) $scope.activelink[18] = "active";
            if ($scope.url.indexOf("/Admin/dsuser") > 0) $scope.activelink[19] = "active";
            if ($scope.url.indexOf("/Admin/configdoc") > 0) $scope.activelink[20] = "active";
            if ($scope.url.indexOf("/Admin/phanquyen") > 0) $scope.activelink[21] = "active";
            if ($scope.url.indexOf("/Admin/logaction") > 0) $scope.activelink[22] = "active";
        }
        $scope.show = function (id) {
            for (var i = 0; i < $scope.pData.length; i++) {
                if (id == $scope.pData[i].ID)
                    return true;
            }
            return true;
        }
        $scope.showgroup = function (id) {
            for (var i = 0; i < $scope.pData.length; i++) {
                if (id == $scope.pData[i].NHOMID)
                    return true;
            }
            return true;
        }
    }]);
}());