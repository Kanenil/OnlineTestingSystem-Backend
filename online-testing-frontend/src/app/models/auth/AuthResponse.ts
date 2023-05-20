import {ITokens} from "./Tokens";

export interface IAuthResponse {
  tokens: ITokens,
  expires: string
}
