# AWS Configuration
aws_region   = "us-west-2"
project_name = "petclinic"
environment  = "dev"

# EKS Configuration
cluster_version = "1.29"

# VPC Configuration
vpc_cidr           = "10.0.0.0/16"
availability_zones = ["us-west-2a", "us-west-2b", "us-west-2c"]

# Node Group Configuration
node_instance_types = ["t3.medium"]
node_desired_size   = 2
node_min_size       = 1
node_max_size       = 4
node_disk_size      = 50

# Features
enable_cluster_autoscaler = true

# Additional Tags
additional_tags = {
  Application = "spring-petclinic"
}
