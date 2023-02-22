import { Component, OnInit } from '@angular/core';
import { Arquivo } from 'src/app/models/arquivo';
import { RequestService } from 'src/app/services/request/request.service';

@Component({
  selector: 'app-list-files',
  templateUrl: './list-files.component.html',
  styleUrls: ['./list-files.component.scss']
})
export class ListFilesComponent implements OnInit {

  files: File[] = [];

  constructor(private requestService: RequestService) { }

  ngOnInit(): void {
  }

  getListFiles() {
    this.requestService.getFileList()
      .subscribe(
        (res) => this.files = res
      )
  }
}
