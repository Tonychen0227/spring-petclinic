# AWS EKS Infrastructure for Spring PetClinic

This Terraform configuration creates an AWS EKS cluster for deploying the Spring PetClinic application.

## Architecture

- **VPC** with public and private subnets across 3 availability zones
- **EKS Cluster** with managed node groups
- **NAT Gateway** for private subnet internet access
- **EBS CSI Driver** for persistent volume support
- **Cluster Autoscaler** support (optional)

## Prerequisites

- [Terraform](https://www.terraform.io/downloads.html) >= 1.0
- [AWS CLI](https://aws.amazon.com/cli/) configured with appropriate credentials
- [kubectl](https://kubernetes.io/docs/tasks/tools/) for cluster management

## Usage

### 1. Initialize Terraform

```bash
cd infra
terraform init
```

### 2. Review the plan

```bash
terraform plan
```

### 3. Apply the configuration

```bash
terraform apply
```

### 4. Configure kubectl

After the cluster is created, configure kubectl:

```bash
aws eks update-kubeconfig --region us-west-2 --name petclinic-dev-eks
```

## Configuration

Edit `terraform.tfvars` to customize:

| Variable | Description | Default |
|----------|-------------|---------|
| `aws_region` | AWS region | `us-west-2` |
| `environment` | Environment name | `dev` |
| `cluster_version` | Kubernetes version | `1.29` |
| `node_instance_types` | EC2 instance types | `["t3.medium"]` |
| `node_desired_size` | Desired node count | `2` |
| `node_min_size` | Minimum nodes | `1` |
| `node_max_size` | Maximum nodes | `4` |

## Outputs

After applying, Terraform outputs useful information:

- `cluster_name` - EKS cluster name
- `cluster_endpoint` - Kubernetes API endpoint
- `configure_kubectl` - Command to configure kubectl

## Cleanup

To destroy all resources:

```bash
terraform destroy
```

## Cost Estimation (Development)

Approximate monthly costs for default configuration:
- EKS Control Plane: ~$73/month
- NAT Gateway: ~$32/month + data transfer
- EC2 Instances (2x t3.medium): ~$60/month
- **Total**: ~$165/month

> Note: Actual costs may vary based on usage and region.

## Security Considerations

- Cluster endpoint is publicly accessible (for development)
- Private subnets for worker nodes
- IAM roles with least privilege using IRSA
- Enable encryption at rest for production
