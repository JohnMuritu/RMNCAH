import * as ACTION_TYPES from '../actions/actions';

const jwt = require('jsonwebtoken');

const initialState = {
  userToken: null,
  user: {},
  authenticated: false
};

const reducer = (state = initialState, action) => {
  switch (action.type) {
    case ACTION_TYPES.AUTHENTICATION:
      return { 
        ...state,
        userToken: action.payload,
        user: jwt.decode(action.payload),
        authenticated: true
      };

    case ACTION_TYPES.LOG_OUT:
      return initialState;

    default:
      return state;
  }
};
export default reducer;
