import { Role } from "./role";

export class User {
  id: number;
  username: string;
  accountName: string;
  displayName: string;
  email: string;
  designation: string;
  department: string;
  password: string;
  firstName: string;
  lastName: string;
  role: Role;
  token: string;
}
