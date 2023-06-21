import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Subject } from 'src/app/core/models/subject';
import { SubjectService } from 'src/app/core/services/subject.service';

@Component({
  selector: 'app-subject',
  templateUrl: './subject.component.html',
  styleUrls: ['./subject.component.css']
})
export class SubjectComponent implements OnInit{
  subjects: Observable<Subject[]> | undefined;

  constructor(private apiService: SubjectService) {}

  ngOnInit(): void {
    this.subjects = this.apiService.getAll();
  }
}
