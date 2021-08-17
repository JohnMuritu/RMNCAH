import { useEffect } from 'react';
import { Link as RouterLink, useLocation } from 'react-router-dom';
import { useSelector } from 'react-redux';
import PropTypes from 'prop-types';
import {
  Avatar,
  Box,
  Button,
  Divider,
  Drawer,
  Hidden,
  List,
  Typography
} from '@material-ui/core';
import {
  AlertCircle as AlertCircleIcon,
  BarChart as BarChartIcon,
  Lock as LockIcon,
  Settings as SettingsIcon,
  ShoppingBag as ShoppingBagIcon,
  User as UserIcon,
  UserPlus as UserPlusIcon,
  Users as UsersIcon,
  Book
} from 'react-feather';
import NavItem from './NavItem';

const items = [
  // {
  //   href: '/app/dashboard',
  //   icon: BarChartIcon,
  //   title: 'Dashboard'
  // },
  {
    href: '/app/registerclient',
    icon: Book,
    title: 'Clients'
  },
  // {
  //   href: '/app/clientClinicalDetails',
  //   icon: UsersIcon,
  //   title: 'Client Clinical Details'
  // },
  {
    href: '/app/reports',
    icon: BarChartIcon,
    title: 'Reports'
  },
  {
    href: '/app/account',
    icon: UserIcon,
    title: 'Account'
  },
  // {
  //   href: '/app/settings',
  //   icon: SettingsIcon,
  //   title: 'Settings'
  // },
  // {
  //   href: '/login',
  //   icon: LockIcon,
  //   title: 'Login'
  // },
  {
    href: '/app/adduser',
    icon: UserPlusIcon,
    title: 'Add User'
  }
  // {
  //   href: '/404',
  //   icon: AlertCircleIcon,
  //   title: 'Error'
  // }
];

const DashboardSidebar = ({ onMobileClose, openMobile }) => {
  const location = useLocation();
  const firstName = useSelector((state) => state.main_reducer.user.FirstName);
  const lastName = useSelector((state) => state.main_reducer.user.LastName);
  const jobTitle = useSelector((state) => state.main_reducer.user.JobTitle);

  useEffect(() => {
    if (openMobile && onMobileClose) {
      onMobileClose();
    }
  }, [location.pathname]);

  const content = (
    <Box
      sx={{
        display: 'flex',
        flexDirection: 'column',
        height: '100%'
      }}
    >
      <Box
        sx={{
          alignItems: 'center',
          display: 'flex',
          flexDirection: 'column',
          p: 2
        }}
      >
        <Avatar
          component={RouterLink}
          src="/static/images/avatars/avatar_6.png"
          sx={{
            cursor: 'pointer',
            width: 64,
            height: 64
          }}
          to="/app/account"
        />
        <Typography color="textPrimary" variant="h5">
          {firstName} {lastName}
        </Typography>
        <Typography color="textSecondary" variant="body2">
          {jobTitle}
        </Typography>
      </Box>
      <Divider />
      <Box sx={{ p: 2 }}>
        <List>
          {items.map((item) => (
            <NavItem
              href={item.href}
              key={item.title}
              title={item.title}
              icon={item.icon}
            />
          ))}
        </List>
      </Box>
      <Box sx={{ flexGrow: 1 }} />
    </Box>
  );

  return (
    <>
      <Hidden lgUp>
        <Drawer
          anchor="left"
          onClose={onMobileClose}
          open={openMobile}
          variant="temporary"
          PaperProps={{
            sx: {
              width: 256
            }
          }}
        >
          {content}
        </Drawer>
      </Hidden>
      <Hidden lgDown>
        <Drawer
          anchor="left"
          open
          variant="persistent"
          PaperProps={{
            sx: {
              width: 256,
              top: 64,
              height: 'calc(100% - 64px)'
            }
          }}
        >
          {content}
        </Drawer>
      </Hidden>
    </>
  );
};

DashboardSidebar.propTypes = {
  onMobileClose: PropTypes.func,
  openMobile: PropTypes.bool
};

DashboardSidebar.defaultProps = {
  onMobileClose: () => {},
  openMobile: false
};

export default DashboardSidebar;
