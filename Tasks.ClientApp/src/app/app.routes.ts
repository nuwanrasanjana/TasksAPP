import { Routes } from '@angular/router';
import { TasksComponent } from './features/tasks/components/tasks/tasks.component';
import { AuthComponent } from './features/auth/auth/auth.component';
import { authGuard } from './core/guards/auth.guard';

export const routes: Routes = [
    {
        path:'',
        component:AuthComponent
    },
    {
        path:'login',
        component:AuthComponent
    },
    {
        path:'tasks',
        component:TasksComponent,
        canActivate:[authGuard]
    },
    {
        path: 'tasks/:id',
        component: TasksComponent,
        canActivate: [authGuard]
    },
];
