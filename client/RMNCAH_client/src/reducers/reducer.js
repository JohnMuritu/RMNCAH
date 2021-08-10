import * as ACTION_TYPES from '../actions/actions';

const jwt = require('jsonwebtoken');

const initialState = {
  userToken: null,
  user: {},
  authenticated: false,
  clientDetails: {
    clientId: '',
    fullNames: '',
    dob: '',
    village: '',
    phoneNumber: '',
    alternativePhoneNumber: '',
    hfLinked: '',
    otherHFAttended: ''
  },
  update_client_details: 1,
  update_client_list: 0,
  client_list: []
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

    case ACTION_TYPES.SET_CLIENT_DETAILS:
      return {...state, clientDetails: action.payload};
    
    case ACTION_TYPES.UPDATE_CLIENT_DETAILS:
      return {...state, update_client_details: action.payload};

    case ACTION_TYPES.UPDATE_CLIENT_LIST:
      return {...state, update_client_list: action.payload};

    case ACTION_TYPES.CLIENT_LIST:
      return {...state, client_list: action.payload};

    case ACTION_TYPES.LOG_OUT:
      return initialState;

    default:
      return state;
  }
};
export default reducer;
