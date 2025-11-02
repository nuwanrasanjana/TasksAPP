import { Component, EventEmitter, Input, Output } from '@angular/core';
import { TaskItem } from '../../../../core/models/task.model';
import { NgFor } from '@angular/common';
import { TaskService } from '../../services/task.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-task-list',
  imports: [NgFor],
  templateUrl: './task-list.component.html',
  styleUrl: './task-list.component.scss'
})
export class TaskListComponent {
  @Input() tasks: TaskItem[] = []
  @Output() editTask = new EventEmitter<TaskItem>()
  @Output() refresh = new EventEmitter<void>()
  @Output() successAlert = new EventEmitter<boolean>()
  constructor(private taskService: TaskService, private router: Router){

  }

  onEdit(task:TaskItem){
    this.router.navigate(['/tasks', task.id]);
    this.editTask.emit(task)

  }
  onDelete(id:string){
    if(confirm('Are you sure you want to delete this task?'))
      this.taskService.deleteTask(id).subscribe(()=>{
        this.refresh.emit()
        this.successAlert.emit(true)
      },()=>{
        this.successAlert.emit(false)
      })
  }

}
