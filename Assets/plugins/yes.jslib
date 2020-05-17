mergeInto(LibraryManager.library, {

    InsertJWToken: function(token){
        try{
        var converted= Pointer_stringify(token)
        localStorage.setItem('token', converted);
        console.log(localStorage.getItem('token'));
        var xhr = new XMLHttpRequest();
        xhr.open('GET','http://localhost:7000/api/v1/auth/me',true);
        xhr.setRequestHeader("authorization","Bearer "+localStorage.getItem('token'));
        xhr.send();
        xhr.onreadystatechange = function() { 
            if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
                
                var parsed=JSON.parse(this.response);
                console.log(parsed);
                var userData= parsed.data;
                console.log(userData);

                localStorage.setItem('name',useraData.name);
                localStorage.setItem('uid',useraData.name_id);
                localStorage.setItem('email',useraData.email);
                console.log(localStorage.getItem('name')+" succesfully registered");
            }
        }
        }catch(err){
            console.log(err);
            alert(err.message);
        }
    },

    GetUserData:function(){
        var nameStr = localStorage.getItem('name');
        var emailStr= localStorage.getItem('email');
        var returnStr= nameStr+"|"+emailStr;
        if(nameStr===null||emailStr===null){
            return null;
        }else{
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
        //returns nameStr|emailStr
        }
        

    }
    ,

    Logout:function(){
        localStorage.clear();
        

    }

});