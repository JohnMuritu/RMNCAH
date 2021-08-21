import { useState, useEffect } from 'react';
import {
  Box,
  Button,
  Card,
  CardContent,
  CardHeader,
  Divider,
  Grid,
  TextField,
  MenuItem
} from '@material-ui/core';
import DateFnsUtils from '@date-io/date-fns';
import {
  MuiPickersUtilsProvider,
  KeyboardDatePicker
} from '@material-ui/pickers';
import { useSelector, useDispatch } from 'react-redux';
import * as Yup from 'yup';
import { useFormik } from 'formik';
import axios from 'axios';
import { NotificationManager } from 'react-notifications';
import { v4 as uuidv4 } from 'uuid';
import * as ACTION_TYPES from '../../actions/actions';

// const deliveryOptions = [
//   {
//     value: '0',
//     label: 'Select'
//   },
//   {
//     value: '1',
//     label: 'SBA'
//   },
//   {
//     value: '2',
//     label: 'HD (home delivery)'
//   },
//   {
//     value: '3',
//     label: 'BBA(Born before arrival)'
//   }
// ];

// const adultRemarksOptions = [
//   {
//     value: '0',
//     label: 'Select'
//   },
//   {
//     value: '1',
//     label: 'Abortion'
//   },
//   {
//     value: '2',
//     label: 'Miscarried'
//   },
//   {
//     value: '3',
//     label: 'Still birth'
//   },
//   {
//     value: '4',
//     label: 'Maternal death'
//   }
// ];

// const childRemarksOptions = [
//   {
//     value: '0',
//     label: 'Select'
//   },
//   {
//     value: '1',
//     label: 'Child death'
//   }
// ];

const ClientClinicalDetails = (props) => {
  const dispatch = useDispatch();

  const fullNames = useSelector(
    (state) => state.main_reducer.clientDetails.fullNames
  );
  const dob = useSelector((state) => state.main_reducer.clientDetails.dob);
  const clientId = useSelector(
    (state) => state.main_reducer.clientDetails.clientId
  );
  const hfLinked = useSelector(
    (state) => state.main_reducer.clientDetails.hfLinked.facilityName
  );

  const clientClinicalDetailsFetched = useSelector(
    (state) => state.main_reducer.clientClinicalDetails
  );

  const [deliveryOptions, setDeliveryOptions] = useState(null);
  const [adultRemarksOptions, setAdultRemarksOptions] = useState(null);
  const [childRemarksOptions, setChildRemarksOptions] = useState(null);

  const [parentRemarkSelected, setParentRemarkSelected] = useState(null);

  const calculate_age = () => {
    var today = new Date();
    var birthDate = new Date(dob); // create a date object directly from `dob1` argument
    var age_now = today.getFullYear() - birthDate.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
      age_now--;
    }
    return age_now;
  };

  const handleSave = (clientClinicalDetails) => {
    console.log(ClientClinicalDetails);
    if (clientClinicalDetails.clientClinicalDetailsId === '') {
      clientClinicalDetails.clientClinicalDetailsId = uuidv4();
      console.log(clientClinicalDetails);
      axios
        .post('/api/client/addClientClinicalDetails', clientClinicalDetails)
        .then((response) => {
          NotificationManager.success('Saved Successfully!', '', 2000);
          formik.resetForm();
          dispatch({
            type: ACTION_TYPES.UPDATE_COMPONENT
          });
        })
        .catch((error) => {
          console.log(`error : ${error}`);
          NotificationManager.error('Error Save!', '', 10000);
          clientClinicalDetails.clientClinicalDetailsId = '';
        });
    } else {
      console.log(clientClinicalDetails);
      axios
        .post('/api/client/UpdateClientClinicalDetails', clientClinicalDetails)
        .then((response) => {
          NotificationManager.success('Updated Successfully!', '', 2000);
          dispatch({
            type: ACTION_TYPES.UPDATE_COMPONENT
          });
        })
        .catch((error) => {
          console.log(`error : ${error}`);
          NotificationManager.error('Error Update!', '', 10000);
        });
    }

    // axios
    //   .get('/api/client/clientdetails')
    //   .then((response) => {
    //     dispatch({
    //       type: ACTION_TYPES.CLIENT_LIST,
    //       payload: response.data
    //     });
    //   })
    //   .catch((error) => {
    //     console.log(`error : ${error}`);
    //   });
  };

  const getDeliveryOptions = () => {
    axios
      .get('/api/utils/deliveryoptions')
      .then((response) => {
        setDeliveryOptions(response.data);
      })
      .catch((error) => {
        console.log(`error : ${error}`);
      });
  };

  const getAdultRemarks = () => {
    axios
      .get('/api/utils/adultremarks')
      .then((response) => {
        setAdultRemarksOptions(response.data);
      })
      .catch((error) => {
        console.log(`error : ${error}`);
      });
  };

  const getChildRemarks = () => {
    axios
      .get('/api/utils/childremarks')
      .then((response) => {
        setChildRemarksOptions(response.data);
      })
      .catch((error) => {
        console.log(`error : ${error}`);
      });
  };

  useEffect(() => {
    if (clientId === clientClinicalDetailsFetched.clientId) {
      formik.setValues(clientClinicalDetailsFetched);

      if (clientClinicalDetailsFetched.adultRemarksOptions !== null) {
        setParentRemarkSelected(
          clientClinicalDetailsFetched.adultRemarksOptions.option
        );
      } else {
        setParentRemarkSelected(null);
      }
    }

    if (!deliveryOptions) {
      getDeliveryOptions();
    }

    if (!adultRemarksOptions) {
      getAdultRemarks();
    }

    if (!childRemarksOptions) {
      getChildRemarks();
    }
  }, [clientClinicalDetailsFetched]);

  const SignupSchema = Yup.object().shape({
    // anc1: Yup.date(),
    // anc2: Yup.date().when(
    //   'anc1',
    //   (anc1, schema) =>
    //     anc1 && schema.min(anc1, 'ANC2 should be greater than ANC1')
    // )
    // anc3: Yup.date().when(
    //   'anc2',
    //   (anc2, schema) =>
    //     anc2 && schema.min(anc2, 'ANC3 should be greater than ANC2')
    // )
    // anc4: Yup.date().when(
    //   'anc3',
    //   (anc3, schema) =>
    //     anc3 && schema.min(anc3, 'ANC4 should be greater than ANC3')
    // ),
    // anc5: Yup.date().when(
    //   'anc4',
    //   (anc4, schema) =>
    //     anc4 && schema.min(anc4, 'ANC5 should be greater than ANC4')
    // ),
    // edd: Yup.date().when(
    //   'anc5',
    //   (anc5, schema) =>
    //     anc5 && schema.min(anc5, 'EDD should be greater than ANC5')
    // )
  });

  const formik = useFormik({
    initialValues: {
      clientClinicalDetailsId: '',
      clientId: clientId,
      babyName: '',
      anc1: null,
      anc2: null,
      anc3: null,
      anc4: null,
      anc5: null,
      edd: null,
      remarksParent: 0,
      delivery: 0,
      penta1: null,
      penta2: null,
      penta3: null,
      mr1: null,
      remarksChild: 0
    },
    onSubmit: (values) => {
      handleSave(values);
    },
    validationSchema: SignupSchema,
    enableReinitialize: true
  });

  return (
    <form onSubmit={formik.handleSubmit}>
      <Card>
        <CardHeader
          // subheader="Enter client clinical details"
          title="Client Clinical Details"
        />
        <Divider />

        <CardContent>
          <Grid container spacing={3} marginBottom={3}>
            <Grid item md={3} xs={12}>
              <TextField
                fullWidth
                label="Full names"
                name="fullNames"
                value={fullNames}
                variant="outlined"
                inputProps={{
                  readOnly: true
                }}
              />
            </Grid>
            <Grid item md={3} xs={12}>
              <TextField
                fullWidth
                label="Age"
                name="age"
                value={calculate_age()}
                variant="outlined"
                inputProps={{
                  readOnly: true
                }}
              />
            </Grid>
            <Grid item md={3} xs={12}>
              <TextField
                fullWidth
                label="HF Linked"
                name="hfLinked"
                value={hfLinked}
                variant="outlined"
                inputProps={{
                  readOnly: true
                }}
              />
            </Grid>

            <Grid item md={3} xs={12}>
              <TextField
                fullWidth
                label="Baby Name"
                name="babyName"
                value={formik.values.babyName}
                onChange={formik.handleChange}
                variant="outlined"
              />
            </Grid>
          </Grid>

          <Grid container spacing={3}>
            <MuiPickersUtilsProvider utils={DateFnsUtils}>
              <Grid item md={3} xs={12}>
                <KeyboardDatePicker
                  fullWidth
                  autoOk
                  disableFuture={true}
                  variant="inline"
                  inputVariant="outlined"
                  label="ANC 1"
                  format="dd-MMM-yyyy"
                  value={formik.values.anc1}
                  InputAdornmentProps={{ position: 'end' }}
                  onChange={(val) => {
                    formik.setFieldValue('anc1', val);
                  }}
                  helperText={formik.touched.anc1 && formik.errors.anc1}
                  error={Boolean(formik.touched.anc1 && formik.errors.anc1)}
                  size="small"
                />
              </Grid>
              <Grid item md={3} xs={12}>
                <KeyboardDatePicker
                  fullWidth
                  autoOk
                  disableFuture={true}
                  variant="inline"
                  inputVariant="outlined"
                  label="ANC 2"
                  format="dd-MMM-yyyy"
                  value={formik.values.anc2}
                  InputAdornmentProps={{ position: 'end' }}
                  onChange={(val) => {
                    formik.setFieldValue('anc2', val);
                  }}
                  helperText={formik.touched.anc2 && formik.errors.anc2}
                  error={Boolean(formik.touched.anc2 && formik.errors.anc2)}
                  size="small"
                />
              </Grid>
              <Grid item md={3} xs={12}>
                <KeyboardDatePicker
                  fullWidth
                  autoOk
                  disableFuture={true}
                  variant="inline"
                  inputVariant="outlined"
                  label="ANC 3"
                  format="dd-MMM-yyyy"
                  value={formik.values.anc3}
                  InputAdornmentProps={{ position: 'end' }}
                  onChange={(val) => {
                    formik.setFieldValue('anc3', val);
                  }}
                />
              </Grid>
              <Grid item md={3} xs={12}>
                <KeyboardDatePicker
                  fullWidth
                  autoOk
                  disableFuture={true}
                  variant="inline"
                  inputVariant="outlined"
                  label="ANC 4"
                  format="dd-MMM-yyyy"
                  value={formik.values.anc4}
                  InputAdornmentProps={{ position: 'end' }}
                  onChange={(val) => {
                    formik.setFieldValue('anc4', val);
                  }}
                />
              </Grid>
              <Grid item md={3} xs={12}>
                <KeyboardDatePicker
                  fullWidth
                  autoOk
                  disableFuture={true}
                  variant="inline"
                  inputVariant="outlined"
                  label="ANC 5"
                  format="dd-MMM-yyyy"
                  value={formik.values.anc5}
                  InputAdornmentProps={{ position: 'end' }}
                  onChange={(val) => {
                    formik.setFieldValue('anc5', val);
                  }}
                />
              </Grid>
              <Grid item md={3} xs={12}>
                <KeyboardDatePicker
                  fullWidth
                  autoOk
                  disableFuture={true}
                  variant="inline"
                  inputVariant="outlined"
                  label="EDD"
                  format="dd-MMM-yyyy"
                  value={formik.values.edd}
                  InputAdornmentProps={{ position: 'end' }}
                  onChange={(val) => {
                    formik.setFieldValue('edd', val);
                  }}
                />
              </Grid>
              <Grid item md={3} xs={12}>
                <TextField
                  fullWidth
                  name="remarksParent"
                  select
                  label="Remarks (Parent)"
                  value={formik.values.remarksParent}
                  onChange={(e, val) => {
                    formik.handleChange(e);
                    setParentRemarkSelected(val.props.children);
                    formik.setFieldValue('delivery', null);
                    formik.setFieldValue('penta1', null);
                    formik.setFieldValue('penta2', null);
                    formik.setFieldValue('penta3', null);
                    formik.setFieldValue('mr1', null);
                    formik.setFieldValue('remarksChild', null);
                  }}
                >
                  <MenuItem value={0}>Select</MenuItem>
                  {adultRemarksOptions &&
                    adultRemarksOptions.map((option) => (
                      <MenuItem key={option.id} value={option.id}>
                        {option.option}
                      </MenuItem>
                    ))}
                </TextField>
              </Grid>
              <Grid item md={3} xs={12}>
                <TextField
                  disabled={
                    parentRemarkSelected === 'Abortion' ||
                    parentRemarkSelected === 'Still birth' ||
                    parentRemarkSelected === 'Maternal death' ||
                    parentRemarkSelected === 'Miscarriage'
                  }
                  fullWidth
                  name="delivery"
                  select
                  label="Delivery"
                  value={formik.values.delivery}
                  onChange={formik.handleChange}
                >
                  <MenuItem value={0}>Select</MenuItem>
                  {deliveryOptions &&
                    deliveryOptions.map((option) => (
                      <MenuItem key={option.id} value={option.id}>
                        {option.option}
                      </MenuItem>
                    ))}
                </TextField>
              </Grid>
              <Grid item md={3} xs={12}>
                <KeyboardDatePicker
                  disabled={
                    parentRemarkSelected === 'Abortion' ||
                    parentRemarkSelected === 'Still birth' ||
                    parentRemarkSelected === 'Maternal death' ||
                    parentRemarkSelected === 'Miscarriage'
                  }
                  fullWidth
                  autoOk
                  disableFuture={true}
                  variant="inline"
                  inputVariant="outlined"
                  label="PENTA 1"
                  format="dd-MMM-yyyy"
                  value={formik.values.penta1}
                  InputAdornmentProps={{ position: 'end' }}
                  onChange={(val) => {
                    formik.setFieldValue('penta1', val);
                  }}
                />
              </Grid>
              <Grid item md={3} xs={12}>
                <KeyboardDatePicker
                  disabled={
                    parentRemarkSelected === 'Abortion' ||
                    parentRemarkSelected === 'Still birth' ||
                    parentRemarkSelected === 'Maternal death' ||
                    parentRemarkSelected === 'Miscarriage'
                  }
                  fullWidth
                  autoOk
                  disableFuture={true}
                  variant="inline"
                  inputVariant="outlined"
                  label="PENTA 2"
                  format="dd-MMM-yyyy"
                  value={formik.values.penta2}
                  InputAdornmentProps={{ position: 'end' }}
                  onChange={(val) => {
                    formik.setFieldValue('penta2', val);
                  }}
                />
              </Grid>
              <Grid item md={3} xs={12}>
                <KeyboardDatePicker
                  disabled={
                    parentRemarkSelected === 'Abortion' ||
                    parentRemarkSelected === 'Still birth' ||
                    parentRemarkSelected === 'Maternal death' ||
                    parentRemarkSelected === 'Miscarriage'
                  }
                  fullWidth
                  autoOk
                  disableFuture={true}
                  variant="inline"
                  inputVariant="outlined"
                  label="PENTA 3"
                  format="dd-MMM-yyyy"
                  value={formik.values.penta3}
                  InputAdornmentProps={{ position: 'end' }}
                  onChange={(val) => {
                    formik.setFieldValue('penta3', val);
                  }}
                />
              </Grid>
              <Grid item md={3} xs={12}>
                <KeyboardDatePicker
                  disabled={
                    parentRemarkSelected === 'Abortion' ||
                    parentRemarkSelected === 'Still birth' ||
                    parentRemarkSelected === 'Maternal death' ||
                    parentRemarkSelected === 'Miscarriage'
                  }
                  fullWidth
                  autoOk
                  disableFuture={true}
                  variant="inline"
                  inputVariant="outlined"
                  label="MR 1"
                  format="dd-MMM-yyyy"
                  value={formik.values.mr1}
                  InputAdornmentProps={{ position: 'end' }}
                  onChange={(val) => {
                    formik.setFieldValue('mr1', val);
                  }}
                />
              </Grid>
              <Grid item md={3} xs={12}>
                <TextField
                  disabled={
                    parentRemarkSelected === 'Abortion' ||
                    parentRemarkSelected === 'Still birth' ||
                    parentRemarkSelected === 'Maternal death' ||
                    parentRemarkSelected === 'Miscarriage'
                  }
                  fullWidth
                  name="remarksChild"
                  select
                  label="Remarks (Child)"
                  value={formik.values.remarksChild}
                  onChange={formik.handleChange}
                >
                  <MenuItem value={0}>Select</MenuItem>
                  {childRemarksOptions &&
                    childRemarksOptions.map((option) => (
                      <MenuItem key={option.id} value={option.id}>
                        {option.option}
                      </MenuItem>
                    ))}
                </TextField>
              </Grid>
            </MuiPickersUtilsProvider>
          </Grid>
        </CardContent>
        <Divider />
        <Box
          sx={{
            display: 'flex',
            justifyContent: 'flex-end',
            p: 2
          }}
        >
          <Button
            color="primary"
            variant="contained"
            onClick={() => formik.resetForm()}
            style={{ marginRight: 5 }}
          >
            Reset
          </Button>
          <Button color="primary" variant="contained" type="submit">
            Save details
          </Button>
        </Box>
      </Card>
    </form>
  );
};

export default ClientClinicalDetails;
