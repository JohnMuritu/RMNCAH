import { Link as RouterLink, useNavigate } from 'react-router-dom';
import { Helmet } from 'react-helmet';
import * as Yup from 'yup';
import { Formik } from 'formik';
import {
  Box,
  Button,
  Checkbox,
  Container,
  FormHelperText,
  Link,
  TextField,
  Typography
} from '@material-ui/core';
import axios from 'axios';
import { NotificationManager } from 'react-notifications';

const Register = () => {
  const navigate = useNavigate();

  const handleRegistration = (values) => {
    axios
      .post('/api/user/signup', values)
      .then((response) => {
        NotificationManager.success('Registration Successful!', '', 2000);
        // navigate('/app/registerclient');
      })
      .catch((error) => {
        console.log(`error : ${error}`);
        NotificationManager.error('Error occured!!!', '', 2000);
      });
  };

  return (
    <>
      <Helmet>
        <title>Register | Material Kit</title>
      </Helmet>
      <Box
        sx={{
          backgroundColor: 'background.default',
          display: 'flex',
          flexDirection: 'column',
          height: '100%',
          justifyContent: 'center'
        }}
      >
        <Container maxWidth="sm">
          <Formik
            initialValues={{
              username: '',
              email: '',
              firstName: '',
              lastName: '',
              jobTitle: '',
              password: '',
              confirmPassword: ''
            }}
            validationSchema={Yup.object().shape({
              username: Yup.string().max(255).required('Last name is required'),
              email: Yup.string()
                .email('Must be a valid email')
                .max(255)
                .required('Email is required'),
              firstName: Yup.string()
                .max(255)
                .required('First name is required'),
              password: Yup.string()
                .min(6, 'Minimum 6 characters long')
                .max(255)
                .required('password is required')
                .matches(
                  /^.*(?=.{6,})((?=.*[!@#$%^&*()\-_=+{};:,<.>]){1})(?=.*\d)((?=.*[a-z]){1})((?=.*[A-Z]){1}).*$/,
                  'Password must contain at least 6 characters, one uppercase, one number and one special case character'
                ),
              confirmPassword: Yup.string()
                .required('Please confirm your password')
                .when('password', {
                  is: (password) =>
                    password && password.length > 0 ? true : false,
                  then: Yup.string().oneOf(
                    [Yup.ref('password')],
                    "Password doesn't match"
                  )
                })
            })}
            onSubmit={(values) => {
              handleRegistration(values);
              // navigate('/app/dashboard', { replace: true });
            }}
          >
            {({
              errors,
              handleBlur,
              handleChange,
              handleSubmit,
              isSubmitting,
              touched,
              values
            }) => (
              <form onSubmit={handleSubmit}>
                <Box sx={{ mb: 3 }}>
                  <Typography color="textPrimary" variant="h2">
                    Create new account
                  </Typography>
                </Box>
                <TextField
                  error={Boolean(touched.username && errors.username)}
                  fullWidth
                  helperText={touched.username && errors.username}
                  label="Username"
                  margin="normal"
                  name="username"
                  onBlur={handleBlur}
                  onChange={handleChange}
                  value={values.username}
                  variant="outlined"
                />
                <TextField
                  error={Boolean(touched.firstName && errors.firstName)}
                  fullWidth
                  helperText={touched.firstName && errors.firstName}
                  label="First name"
                  margin="normal"
                  name="firstName"
                  onBlur={handleBlur}
                  onChange={handleChange}
                  value={values.firstName}
                  variant="outlined"
                />
                <TextField
                  error={Boolean(touched.lastName && errors.lastName)}
                  fullWidth
                  helperText={touched.lastName && errors.lastName}
                  label="Last name"
                  margin="normal"
                  name="lastName"
                  onBlur={handleBlur}
                  onChange={handleChange}
                  value={values.lastName}
                  variant="outlined"
                />
                <TextField
                  error={Boolean(touched.jobTitle && errors.jobTitle)}
                  fullWidth
                  helperText={touched.jobTitle && errors.jobTitle}
                  label="Job Title"
                  margin="normal"
                  name="jobTitle"
                  onBlur={handleBlur}
                  onChange={handleChange}
                  value={values.jobTitle}
                  variant="outlined"
                />
                <TextField
                  error={Boolean(touched.email && errors.email)}
                  fullWidth
                  helperText={touched.email && errors.email}
                  label="Email Address"
                  margin="normal"
                  name="email"
                  onBlur={handleBlur}
                  onChange={handleChange}
                  type="email"
                  value={values.email}
                  variant="outlined"
                />
                <TextField
                  error={Boolean(touched.password && errors.password)}
                  fullWidth
                  helperText={touched.password && errors.password}
                  label="Password"
                  margin="normal"
                  name="password"
                  onBlur={handleBlur}
                  onChange={handleChange}
                  type="password"
                  value={values.password}
                  variant="outlined"
                />
                <TextField
                  error={Boolean(
                    touched.confirmPassword && errors.confirmPassword
                  )}
                  fullWidth
                  helperText={touched.confirmPassword && errors.confirmPassword}
                  label="Password"
                  margin="normal"
                  name="confirmPassword"
                  onBlur={handleBlur}
                  onChange={handleChange}
                  type="password"
                  value={values.confirmPassword}
                  variant="outlined"
                />

                <Box sx={{ py: 2 }}>
                  <Button
                    color="primary"
                    //disabled={isvalid}
                    fullWidth
                    size="large"
                    type="submit"
                    variant="contained"
                  >
                    Create Account
                  </Button>
                </Box>
              </form>
            )}
          </Formik>
        </Container>
      </Box>
    </>
  );
};

export default Register;
