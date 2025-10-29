import { Component, EventEmitter, OnInit, output } from '@angular/core';
import { TaskService } from '../../services/task.service';
import { TaskItem } from '../../../../core/models/task.model';
import { TaskListComponent } from '../task-list/task-list.component';
import { TaskFormComponent } from '../task-form/task-form.component';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-tasks',
  imports: [TaskListComponent,TaskFormComponent,NgIf],
  templateUrl: './tasks.component.html',
  styleUrl: './tasks.component.scss'
})
export class TasksComponent implements OnInit{
  tasks:TaskItem[] = []
  selectedTask?:TaskItem 
  showSuccessAlert?:boolean
  showErrorAlert?:boolean
  
  constructor(private taskService: TaskService){

  }
  ngOnInit(){
    this.loadTasks()
    this.closeAlerts()
  }
  loadTasks(){
    this.taskService.getTasks().subscribe(tasks => this.tasks = tasks);
  }
  onTaskSelected(task:TaskItem){
    this.selectedTask = {...task}
    this.closeAlerts()
  }
  onTaskSaved(){
    this.loadTasks()
    this.selectedTask = undefined
  }
  showAlert(isSuccess:boolean){
    this.closeAlerts()
    if(isSuccess == true){
      this.showSuccessAlert = true
    }else{
      this.showErrorAlert = true
    }
  }
  closeAlerts(){
    this.showSuccessAlert = false
    this.showErrorAlert = false
  }

}
