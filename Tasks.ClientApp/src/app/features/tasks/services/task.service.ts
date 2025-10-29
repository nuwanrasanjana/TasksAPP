import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TaskItem } from '../../../core/models/task.model';
import { HttpClient } from '@angular/common/http';
import { ApiEndpoints } from '../../../core/config/api-endpoints';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private apiURL = ApiEndpoints.TASKS

  constructor(private http : HttpClient) { }

  getTasks(): Observable<TaskItem[]>{
    return this.http.get<TaskItem[]>(this.apiURL)
  }
  addTask(task:TaskItem):Observable<TaskItem>{
    return this.http.post<TaskItem>(this.apiURL,task)
  }
  updateTask(id:string,task:TaskItem):Observable<TaskItem>{
    console.log("inside service",task)
    return this.http.put<TaskItem>(`${this.apiURL}/${id}`,task)
  }
  deleteTask(id:string):Observable<void>{
    return this.http.delete<void>(`${this.apiURL}/${id}`)
  }
}
