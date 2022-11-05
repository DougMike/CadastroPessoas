import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Pessoa } from '../models/pessoa';

@Injectable({
  providedIn: 'root'
})
export class UtilsService {

  private listaSubject = new Subject<Pessoa[]>;


  constructor() { }

  setList(list: Pessoa[]) {
    this.listaSubject.next(list);
  }

  setPhoneMask() {
    const maskPhone = (rawValue: string) => {
      const temp = rawValue.replace(/\D/g, '');
      return ['(', /[0-9]/, /[0-9]/, ')',]
    }
  }
}
