import {IRole} from "../Role";
import {ICourse} from "../courses/Course";

export interface IUser {
  slug: string,
  firstName: string,
  lastName: string,
  image: string,
  email: string,
  backgroundImage: string,
  courses: [
    {
      role: IRole,
      "course": ICourse
    }
  ]
}
