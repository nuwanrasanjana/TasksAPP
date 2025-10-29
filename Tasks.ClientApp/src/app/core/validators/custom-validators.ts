import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export class CustomValidators{
    static passwordMatching() : ValidatorFn{
        return(control : AbstractControl) : ValidationErrors | null => {
            const password = control.get('password')?.value
            const resetPassword = control.get('resetPassword')?.value

            if(!password || !resetPassword)
                return null
            return password === resetPassword ? null : {passwordMismatch : true}


        }
    }
}