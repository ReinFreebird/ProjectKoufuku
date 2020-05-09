mergeInto(LibraryManager.library, {

    InsertJWToken: function(token){
        var converted= Pointer_stringify(token)
        localStorage.setItem('token', converted);
        console.log(localStorage.getItem('token'));
        alert(localStorage.getItem('token'));
        var xhr = new XMLHttpRequest();
        xhr.open('GET','http://localhost:7000/api/v1/auth/getMe',true);
        xhr.setRequestHeader("authorization","Bearer "+localStorage.getItem('token'));
        xhr.send();
        xhr.onreadystatechange = function() { 
            if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
                var parsed=JSON.parse(this.response);
                localStorage.setItem('name',parsed['name']);
                localStorage.setItem('uid',parsed['_id']);
                localStorage.setItem('email',parsed['email']);
            }
        }
    },

    GetUserName:function(){
        var returnStr = localStorage.getItem('name');
        if(returnStr===null){
            return null;
        }else{
            var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
        }
        

    },
    GetUserEmail:function(){
        var returnStr = localStorage.getItem('email');
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;

    }

});