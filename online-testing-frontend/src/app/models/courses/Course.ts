import {IRole} from "../Role";
import {IUser} from "../users/User";

export interface ICourse {
  id: number,
  slug: string,
  code: string,
  image?: string,
  name: string,
  description?: string,
  section?: string,
  isOnlyForCodeAccess: boolean,
  users: [
    {
      role: IRole,
      user: IUser
    }
  ]
}
