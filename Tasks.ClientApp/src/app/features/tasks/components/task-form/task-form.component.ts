import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from '@angular/core';
import { TaskItem } from '../../../../core/models/task.model';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { TaskService } from '../../services/task.service';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-task-form',
  imports: [ReactiveFormsModule,NgIf],
  templateUrl: './task-form.component.html',
  styleUrl: './task-form.component.scss'
})
export class TaskFormComponent implements OnChanges{
  @Input() task?:TaskItem
  @Output() taskSaved = new EventEmitter<void>()
  @Output() successAlert = new EventEmitter<boolean>()

  constructor(private taskService : TaskService){

  }

  ngOnChanges(changes: SimpleChanges): void {
    if(changes['task'] && this.task){
      this.taskForm.patchValue(this.task)
    }else{
      this.resetForm()
    }
  }

  taskForm : FormGroup = new FormGroup({
    description : new FormControl('',[Validators.required]),
    isCompleted : new FormControl(null,[Validators.required])
  })

  onSubmit(){
    console.log("on submit called")
    const taskData = this.taskForm.value
    if(this.task){
      console.log("update called",this.task)
      const updatedTask = {
        ...taskData,
        id : this.task.id
      }
      this.taskService.updateTask(this.task.id,updatedTask).subscribe(()=>{
        this.taskSaved.emit()
        this.successAlert.emit(true)
      },(error)=>{
        console.log("error",error)
        this.successAlert.emit(false)
      })
    }else{
      this.taskService.addTask(taskData).subscribe(()=>{
        this.taskSaved.emit()
        this.successAlert.emit(true)
      },()=>{
        this.successAlert.emit(false)
      })
    }
    this.resetForm()
    console.log("task form values",this.taskForm.value)
  }
  resetForm(){
    this.taskForm.reset({description:'',isCompleted:null})
  }
  onCancel(){
    this.task = undefined
    this.resetForm()
  }

}
