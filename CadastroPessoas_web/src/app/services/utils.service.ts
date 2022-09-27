import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UtilsService {

  constructor() { }

  setPhoneMask(){
    const maskPhone = (rawValue: string) => {
      const temp = rawValue.replace(/\D/g, '');
      return ['(', /[0-9]/,/[0-9]/, ')', ]
    }
  }
}
