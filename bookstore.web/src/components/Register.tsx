import React, { useState, ChangeEvent } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import './style.css';
import { Form, Col, FormGroup, Label, Input, Row, Button, InputGroup, InputGroupText } from "reactstrap";

import UserService from '../services/IUserService';
import UserData from '../types/Register';

export class Register extends React.Component {

    handleChange = (event: any) => { }
    handleSubmit = (event: any) => { }

    render() {
        return (
            <div className='wrapper'>
                <div className='form-wrapper'>
                    <h2>فرم ثبت نام</h2>
                    <br />
                    <Form onSubmit={this.handleSubmit}>
                        <Row>
                            <Col md={6}>
                                <FormGroup>
                                    <div className='firstName'>
                                        <Label for="FirstName">
                                            نام
                                        </Label>
                                        <Input
                                            id="firstName"
                                            name="firstName"
                                            placeholder=""
                                            type="text"
                                        />
                                    </div>
                                </FormGroup>
                            </Col>
                            <Col md={6}>
                                <FormGroup>
                                    <div className='lastName'>
                                        <Label for="LastName">
                                            نام خانوادگی
                                        </Label>
                                        <Input
                                            id="lastName"
                                            name="lastName"
                                            placeholder=""
                                            type="text"
                                        />
                                    </div>
                                </FormGroup>
                            </Col>
                        </Row>
                        <Row>
                            <Col md={6}>
                                <FormGroup>
                                    <div className='userName'>
                                        <Label for="UserName">
                                            نام کاربری
                                        </Label>
                                        <Input
                                            id="userName"
                                            name="userName"
                                            placeholder=""
                                            type="text"
                                        />
                                    </div>
                                </FormGroup>
                            </Col>
                            <Col md={6}>
                                <FormGroup>
                                </FormGroup>
                            </Col>
                        </Row>
                        <Row>
                            <Col md={6}>
                                <FormGroup>
                                    <div className='password'>
                                        <Label for="Password">
                                            گذرواژه
                                        </Label>
                                        <Input
                                            id="password"
                                            name="password"
                                            placeholder=""
                                            type="password"
                                        />
                                    </div>
                                </FormGroup>
                            </Col>
                            <Col md={6}>
                                <FormGroup>
                                    <div className='rePassword'>
                                        <Label for="RePassword">
                                            تکرار گذرواژه
                                        </Label>
                                        <Input
                                            id="rePassword"
                                            name="rePassword"
                                            placeholder=""
                                            type="password"
                                        />
                                    </div>
                                </FormGroup>
                            </Col>
                        </Row>
                        <Row>
                            <Col md={6}>
                                <FormGroup>
                                    <div className='email'>
                                        <Label for="Email">
                                            ایمیل
                                        </Label>
                                        <Input
                                            id="email"
                                            name="email"
                                            placeholder=""
                                            type="email"
                                        />
                                    </div>
                                </FormGroup>
                            </Col>
                            <Col md={6}>
                                <FormGroup>
                                    <div className='mobile'>
                                        <Label for="Mobile">
                                            موبایل
                                        </Label>
                                        <Input
                                            id="exampleState"
                                            name="state"
                                            type="text"
                                        />
                                    </div>
                                </FormGroup>
                            </Col>
                        </Row>                        
                        <Button className="submit">
                            ثبت نام
                        </Button>
                    </Form>
                </div>
            </div>
        );
    }
}