$(function (){
    for (var i = 1; i <= 5; i++) {
        //$("#button" + i).click(console.log("hello everdoby"));
    }
})

function test(s) {
    console.log(s);
    //alert(s);
    Pagin(s,1);
}
function test2(s) {
    console.log(s);
    var s2 = s.split(',');
    Pagin(s2[0], s2[1]);

}

function Pagin(id,page) {
    console.log(id);
    location.href = "/Contract/Index?WalletId=" + id + "&Page=" + page + "&NumberOfElementsByPage=10"
    /*$.ajax({
        url: '/Contract/Index',
        data: {
            WalletId: id,
            Page : 1,
            NumberOfElementsByPage : 5
        },

    }).done(function (result) {
        console.log(result.);
        //return result;
    });
    */  
}



/*
 * 
 *   public Guid WalletId { get; set; }
        public int Page { get; set; }
        public int NumberOfElementsByPage { get; set; }
        */