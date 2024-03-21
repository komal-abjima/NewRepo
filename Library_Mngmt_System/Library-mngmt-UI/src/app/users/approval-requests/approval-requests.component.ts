import { Component } from '@angular/core';
import { AccountStatus, User } from '../../models/model';
import { ApiService } from '../../services/api.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-approval-requests',
  templateUrl: './approval-requests.component.html',
  styleUrl: './approval-requests.component.scss'
})
export class ApprovalRequestsComponent {
  columns: string[] = [
    'userId',
    'userName',
    'email',
    'userType',
    'createdOn',
    'approve',
  ];
  users: User[] = [];

  constructor(private apiService: ApiService, private snackBar: MatSnackBar) {
    apiService.getUsers().subscribe({
      next: (res: User[]) => {
        console.log(res);
        this.users = res.filter(
          (r) => r.accountStatus == AccountStatus.UNAPROOVED
        );
      },
    });
  }

  approve(user: User) {
    this.apiService.approveRequest(user.id).subscribe({
      next: (res) => {
        if (res === 'approved') {
          this.snackBar.open(`Approved for ${user.id}`, 'OK');
        } else this.snackBar.open(`Not Approved`, 'OK');
      },
    });
  }

}
