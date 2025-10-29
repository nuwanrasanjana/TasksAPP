import { Routes } from '@angular/router';
import { TasksComponent } from './features/tasks/components/tasks/tasks.component';
import { AuthComponent } from './features/auth/auth/auth.component';

export const routes: Routes = [
    {
        path:'auth',
        component:AuthComponent
    },
    {
        path:'tasks',
        component:TasksComponent
    }
];
