class PasswordValidityChecker:
    def CheckPassword(self,password):
        lowl=["a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"]
        capl=["A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"]
        num=["0","1","2","3","4","5","6","7","8","9"]
        spec=['$','#',"@"]
        lowlno=caplno=numno=specno=1
        if len(password) in range(6,17):
            for i in password:
                if i in lowl:
                    lowlno=0
                if i in capl:
                    caplno=0
                if i in num:
                    numno=0
                if i in spec:
                    specno=0
            if lowlno==0:
                print("Stage 1 clear")
                if caplno==0:
                    print("Stage 2 clear")
                    if numno==0:
                        print("Stage 3 clear")
                        if specno==0:
                            print("Stage 4 clear")
                            print("Password is valid")
                        else:
                            return ("Password is invalid")
                    else:
                        return ("Password is invalid")
                else:
                    return ("Password is invalid")
            else:
                return ("Password is invalid")
        else:
            return ("Password is invalid")
