function Aux(typeR, url, data, success, fail) {
    $.ajax({
        type : typeR,
        url: '/Contract/Index',
        data: data,
        success : success,
        fail : fail
    });
}
function GetData(url, data, success, fail) {
    Aux('GET', url, data, success, fail);
}

function PostData(url, data, success, fail) {
    Aux('Post', url, data, success, fail);
}
/**
 * public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public string Mail { get; set; }
        public Guid GeographicZone { get; set; }
        public string GeographicZoneName { get; set; }
 


function NewUser(username, password) {
    var data = {
        id : "",
        Username : username,
        Password : password,
        Status : "",
        Mail : "",
        GeographicZone : "",
        GeographicZoneName : ""
    }
    return data;
}
function Login() {
    
    var username = $("#inputText").val();
    var password = $("#inputPassword").val();
    var usr = NewUser(username, password);
    //alert(usr);
    PostData("/Log/Login", usr, success, null);
}

function success(usr) {
    alert("success : "+ usr);
    console.log(usr);
}
function fail() {
    alert("fail");
}
*/