function [J, grad] = costFunctionReg(theta, X, y, lambda)
%COSTFUNCTIONREG Compute cost and gradient for logistic regression with regularization
%   J = COSTFUNCTIONREG(theta, X, y, lambda) computes the cost of using
%   theta as the parameter for regularized logistic regression and the
%   gradient of the cost w.r.t. to the parameters. 

% Initialize some useful values
m = length(y); % number of training examples

% You need to return the following variables correctly 
J = 0;
grad = zeros(size(theta));

% ====================== YOUR CODE HERE ======================
% Instructions: Compute the cost of a particular choice of theta.
%               You should set J to the cost.
%               Compute the partial derivatives and set grad to the partial
%               derivatives of the cost w.r.t. each parameter in theta

[J, grad] = costFunction(theta, X, y);
J = J + (((sum(theta(2:end).^2))*(lambda))/(2*m));

% % This reused code has minor magnitude differences which makes the tests
% % not pass on submit. Hence, need to compute the values locally, as in
% % the next solution.
% "grad(2:end)" because we don't penalize theta0.
% grad(2:end) = grad(2:end) + (grad(2:end)*(lambda/m));

% % Need to use this code to make the tests pass. Very minor differences
% % in values returned.
h = sigmoid(X*theta);
theta1 = [0 ; theta(2:size(theta), :)];
grad = (X'*(h - y)+lambda*theta1)/m;

% =============================================================

end
