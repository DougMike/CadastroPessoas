import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-import-file',
  templateUrl: './import-file.component.html',
  styleUrls: ['./import-file.component.scss']
})
export class ImportFileComponent implements OnInit {

  context: string;

  constructor() { }

  ngOnInit(): void {
  }

  importarArquivo(event: any) {
    console.log(event.target);

  }
}
